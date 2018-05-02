#load "packages/FsLab/Themes/AtomChester.fsx"
#load "packages/FsLab/FsLab.fsx"

open Deedle
open FSharp.Data
open XPlot.Plotly
let wb = WorldBankData.GetDataContext()
let india = wb.Countries.India.Indicators
let china = wb.Countries.China.Indicators

let femaleIndia = series india.``Children out of school, female (% of female primary school age)``
let maleIndia = series india.``Children out of school, male (% of male primary school age)``
let femaleChina = series china.``Children out of school, female (% of female primary school age)``
let maleChina = series china.``Children out of school, male (% of male primary school age)``

let femaleIndiaTrace =
    Bar(
        x = femaleIndia.[1947 .. 2016].Keys,
        y = femaleIndia.[1947 .. 2016].Values,
        name = "Female (India)"
    )

let maleIndiaTrace =
    Bar(
        x = maleIndia.[1947 .. 2016].Keys,
        y = maleIndia.[1947 .. 2016].Values,
        name = "Male (India)"
    )

let femaleChinaTrace =
    Bar(
        x = femaleChina.[1947 .. 2016].Keys,
        y = femaleChina.[1947 .. 2016].Values,
        name = "Female (China)"
    )

let maleChinaTrace =
    Bar(
        x = maleChina.[1947 .. 2016].Keys,
        y = maleChina.[1947 .. 2016].Values,
        name = "Male (China)"
    )

let groupedLayout = Layout(barmode = "group")

[femaleIndiaTrace; maleIndiaTrace; femaleChinaTrace; maleChinaTrace]
|> Chart.Plot
|> Chart.WithLayout groupedLayout
|> Chart.WithXTitle "Year"
|> Chart.WithYTitle "Out of school (%)"
|> Chart.WithTitle "Children out of school"
|> Chart.Show

