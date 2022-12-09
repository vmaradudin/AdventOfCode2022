namespace AdventOfCode2022

open Common.Types
open System

module Day04 =
    let overlaps section1RangeStart section1RangeEnd section2RangeStart section2RangeEnd =
        (section1RangeStart <= section2RangeStart && section2RangeStart <= section1RangeEnd) ||
        (section1RangeStart <= section2RangeEnd && section2RangeEnd <= section1RangeEnd) ||
        (section2RangeStart <= section1RangeStart && section1RangeStart <= section2RangeEnd) ||
        (section2RangeStart <= section1RangeEnd && section1RangeEnd <= section2RangeEnd)

    let includes section1RangeStart section1RangeEnd section2RangeStart section2RangeEnd =
        (section2RangeStart <= section1RangeStart && section1RangeEnd <= section2RangeEnd) ||
        (section1RangeStart <= section2RangeStart && section2RangeEnd <= section1RangeEnd)

    let are condition (value:string) =     
        value.Split([|'-';','|])|> Array.map int |> fun a -> condition a[0] a[1] a[2] a[3]

    let puzzle1 (input:string[]) = 
        input |> Array.where (are includes) |> Array.length

    let puzzle2 (input:string[]) = 
        input |> Array.where (are overlaps) |> Array.length


    let Solution = (new Solution(4, puzzle1, puzzle2) :> ISolution).Execute