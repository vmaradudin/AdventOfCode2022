namespace AdventOfCode2022

open Common.Types
open System

module Day07 =

    let folder accumulator (entry:string) =
        let currentDirectory:string = accumulator|> snd
        let fileSystem = accumulator |> fst
        let line = entry.Split(' ')
        match line.[0] with
        |"$" ->
            match line.[1] with
            |"cd" -> 
                match line.[2] with
                |"/" -> (([|("/",0L)|] |> Array.append fileSystem),"/")
                |".." -> (fileSystem, currentDirectory.TrimEnd('/').LastIndexOf('/') |> fun a -> (currentDirectory.Substring(0, a) + "/"))
                |dir -> (fileSystem, (currentDirectory + dir + "/"))
            |"ls" -> (fileSystem, currentDirectory)
            |_ -> new Exception($"wrong command! '{line}'") |> raise
        |"dir" -> (([|(currentDirectory + line.[1] + "/", 0L)|] |> Array.append fileSystem), currentDirectory)
        |_ -> (([|(currentDirectory + line.[1], (line.[0]|> int64))|] |> Array.append fileSystem), currentDirectory)

    let buildFolderListWithSizes input =
        let foldersList = 
            input
            |> Array.fold folder (Array.empty,"")
            |> fst
            |> Array.map (fun (file,size) -> (file.LastIndexOf('/')|> fun b -> file.Substring(0, b+1)),size)
        foldersList 
            |> Array.map fst 
            |> Array.distinct 
            |> Array.map (fun f -> (f, foldersList|> Array.filter (fun (n, s) -> n.StartsWith(f)) |> Array.sumBy snd))

    let puzzle1 input = 
        input
        |> buildFolderListWithSizes 
        |> Array.map snd 
        |> Array.filter (fun v -> v<100000)
        |> Array.sum

    let puzzle2 input =
        let folderList = input |> buildFolderListWithSizes
        let requiredSpace = 30000000L - (70000000L - (folderList |> Array.find (fun a -> a |> fst = "/")|> snd))
        folderList |> Array.filter (fun a -> a |> snd >=requiredSpace) |> Array.minBy (fun (_, s) -> s) |> snd

    let Solution = (new Solution(7, puzzle1, puzzle2) :> ISolution).Execute