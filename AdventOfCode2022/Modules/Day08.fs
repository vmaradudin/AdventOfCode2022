namespace AdventOfCode2022

open Common.Types
open Common.Tools

module Day08 =
    let buildForest input =
        input 
        |> Array.map (fun a -> a|> Seq.map string |> Seq.map int|> Array.ofSeq)
        |> fun i -> Array2D.init i.Length i[0].Length (fun x y -> i[x][y])

    let visibleFromSide treeHeight treeLine = treeLine |> Array.exists (fun anotherTreeHeight -> anotherTreeHeight >= treeHeight) |> not

    let visible treeHeight treeLines =
        treeLines
        |> Array.exists (fun line -> visibleFromSide treeHeight line)
        
    let calculateVisibleTrees forest =
        forest
        |> Array2D.mapi (fun x y v  -> [|forest[..x-1,y]; forest[x+1..,y]; forest[x,..y-1]; forest[x,y+1..]|] |> visible v)
        |> flatten 
        |> Array.filter id 
        |> Array.length

    let countTrees currentHeight treeLine =
        treeLine
        |> Array.tryFindIndex (fun treeHeight -> treeHeight >= currentHeight)
        |> fun sameOrLongerTree -> 
           match sameOrLongerTree with
           |Some(i) -> i + 1
           |None -> treeLine.Length

    let calculateScenicScores forest =
        forest 
        |> Array2D.mapi (fun x y height  -> 
            ((forest[..x-1,y] |> Array.rev |> countTrees height),
             (forest[x,..y-1] |> Array.rev |> countTrees height),
             (forest[x+1..,y] |> countTrees height),
             (forest[x,y+1..] |> countTrees height)))
        |> Array2D.map (fun (a,b,c,d) -> a*b*c*d)


    let puzzle1 input = 
        input |> buildForest |> calculateVisibleTrees

    let puzzle2 input = 
        input |> buildForest |> calculateScenicScores |> flatten |> Array.max
        
    let Solution = (new Solution(8, puzzle1, puzzle2) :> ISolution).Execute