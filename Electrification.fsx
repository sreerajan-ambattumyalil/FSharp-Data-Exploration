#load "packages/FsLab/Themes/AtomChester.fsx"
#load "packages/FsLab/FsLab.fsx"

open Deedle
open FSharp.Data
open XPlot.Plotly
let wb = WorldBankData.GetDataContext()
let india = wb.Countries.India.Indicators

let inRuralElectricity = series india.``Access to electricity, rural (% of rural population)``
let inUrbanElectricity = series india.``Access to electricity, urban (% of urban population)``

let ruralTrace  =
    Scatter(
        x = inRuralElectricity.[1947 .. 2016].Keys,
        y =inRuralElectricity.[1947 .. 2016].Values
    )

let urbanTrace =
    Scatter(
        x = inUrbanElectricity.[1947 .. 2016].Keys,
        y = inUrbanElectricity.[1947 .. 2016].Values
    )

[ruralTrace; urbanTrace]
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
|> Chart.WithXTitle "Year"
|> Chart.WithYTitle "Electrification (%)"
|> Chart.WithTitle "Electrification in India"
|> Chart.WithLabels ["Rural"; "Urban"]
|> Chart.Show

