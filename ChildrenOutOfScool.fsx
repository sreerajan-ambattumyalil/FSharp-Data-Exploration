#load "packages/FsLab/Themes/AtomChester.fsx"
#load "packages/FsLab/FsLab.fsx"

open Deedle
open FSharp.Data
open XPlot.Plotly
let wb = WorldBankData.GetDataContext()
let india = wb.Countries.India.Indicators

let female = series india.``Children out of school, female (% of female primary school age)``
let male = series india.``Children out of school, male (% of male primary school age)``

let femaleTrace =
    Bar(
        x = female.[1947 .. 2016].Keys,
        y = female.[1947 .. 2016].Values,
        name = "Female"
    )

let maleTrace =
    Bar(
        x = male.[1947 .. 2016].Keys,
        y = male.[1947 .. 2016].Values,
        name = "Male"
    )

let groupedLayout = Layout(barmode = "group")

[femaleTrace; maleTrace]
|> Chart.Plot
|> Chart.WithLayout groupedLayout
|> Chart.WithXTitle "Year"
|> Chart.WithYTitle "Out of school (%)"
|> Chart.WithTitle "Children out of school"
|> Chart.Show

