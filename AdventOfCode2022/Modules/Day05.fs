namespace AdventOfCode2022

open Common.Types
open System

module Day05 =
    let getStacks input =
        let initialState = 
            input 
            |> Array.takeWhile (fun a -> a <> "")
            |> Array.map (fun l -> l |> seq |> Seq.toArray |> Array.chunkBySize 4 |> Array.map (fun a -> a[1]))
            |> array2D
        [|0..((initialState |> Array2D.length2) - 1)|] 
        |> Array.map (fun c -> initialState[*,c] |> fun a -> String.Join(String.Empty,a).Trim() |> seq|> Array.ofSeq) 
        |> Array.append [|[|'0'|]|]

    let commandSplitters ()= [|"move ";" from ";" to "|]

    let rec move count fromStack (toStack:int) st =
        match count with
        |c when c > 0 -> 
            st
            |> Array.mapi (fun i a -> 
                    match (fromStack, toStack) with 
                    |(f,t) when f = i -> Array.tail a
                    |(f,t) when t = i -> Array.insertAt 0 (st.[f] |> Array.head) a
                    |(_,_) -> a)
            |> move (count - 1) fromStack toStack 
        |_ -> st


    let move2 count fromStack (toStack:int) st =
            st
            |> Array.mapi (fun i a -> 
                    match (fromStack, toStack) with 
                    |(f,t) when f = i -> Array.skip count a
                    |(f,t) when t = i -> Array.insertManyAt 0 (st.[f] |> Array.take count) a
                    |(_,_) -> a)

    let folder state (array:int[]) =
        move array.[0] array.[1] array.[2] state
        
    let folder2 state (array:int[]) =
        move2 array.[0] array.[1] array.[2] state
    
    let puzzle1 (input:string[]) = 
        let stacks = input |> getStacks
        input 
        |> Array.skipWhile (fun a -> (a.StartsWith("move") |> not))
        |> Array.map (fun a -> a.Split(commandSplitters(), StringSplitOptions.RemoveEmptyEntries) |> Array.map (string>>int))
        |> Array.fold folder stacks
        |> Array.tail
        |> Array.map Array.head
        |> fun a -> String.Join("", a)

    let puzzle2 (input:string[]) = 
        let stacks = input |> getStacks
        input 
        |> Array.skipWhile (fun a -> (a.StartsWith("move") |> not))
        |> Array.map (fun a -> a.Split(commandSplitters(), StringSplitOptions.RemoveEmptyEntries) |> Array.map (string>>int))
        |> Array.fold folder2 stacks
        |> Array.tail
        |> Array.map Array.head
        |> fun a -> String.Join("", a)


    let Solution = (new Solution(5, puzzle1, puzzle2) :> ISolution).Execute