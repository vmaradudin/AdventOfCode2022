namespace AdventOfCode2022

open Common.Types

module Day03 =
    let getPriority (v:char) =
        match v with
        | v when v>='a' && v<='z' -> int v - int 'a' + 1
        |_ -> int v - int 'A' + 27

    let calc (parts:seq<seq<char[]>>) =
        parts |> Seq.map (fun a -> a |> Seq.map Set.ofSeq |> Set.intersectMany |> Seq.sumBy getPriority) |> Seq.sum


    let puzzle1 (input:string[]) =
        input |> Array.map (Seq.splitInto 2) |> calc
        
    let puzzle2 (input:string[]) =
        input |> Seq.map (Array.ofSeq) |> Seq.chunkBySize 3 |> Seq.map (Seq.ofArray) |> calc

    let Solution = (new Solution(3, puzzle1, puzzle2) :> ISolution).Execute