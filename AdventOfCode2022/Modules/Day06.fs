namespace AdventOfCode2022

open Common.Types
open System

module Day06 =
    let detectFirstUnique len str =
        str |> seq |> Seq.windowed len |> Seq.findIndex (fun a -> a |> Seq.distinct |> Seq.length = len) |> (+) len
    
    let puzzle1 input = 
        input |> Array.head |> detectFirstUnique 4

    let puzzle2 input = 
        input |> Array.head |> detectFirstUnique 14


    let Solution = (new Solution(6, puzzle1, puzzle2) :> ISolution).Execute