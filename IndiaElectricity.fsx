#load "packages/FsLab/Themes/DefaultWhite.fsx"
#load "packages/FsLab/FsLab.fsx"

open Deedle
open FSharp.Data
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle
let wb = WorldBankData.GetDataContext()
let india = wb.Countries.India.Indicators

let inRuralElectricity = series india.``Access to electricity, rural (% of rural population)``
let inUrbanElectricity = series india.``Access to electricity, urban (% of urban population)``

[inRuralElectricity.[1947 .. 2016]; inUrbanElectricity.[1947 .. 2016];]
|> Chart.Line
|> Chart.WithOptions (Options(legend = Legend(position = "bottom")))
|> Chart.WithLabels ["Rural"; "Urban"]
