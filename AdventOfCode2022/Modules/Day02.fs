namespace AdventOfCode2022

open Common.Types
open System

module Day02 =
    
    let calcRound result value=     
        result +
        match value with 
        |"A X" -> 3 + 1 // 4
        |"A Y" -> 6 + 2 // 8
        |"A Z" -> 0 + 3 // 3
        |"B X" -> 0 + 1 // 1
        |"B Y" -> 3 + 2 // 5
        |"B Z" -> 6 + 3 // 9
        |"C X" -> 6 + 1 // 7
        |"C Y" -> 0 + 2 // 2
        |"C Z" -> 3 + 3 // 6
        |_ -> new Exception() |> raise

    let calcRound2 result value=     
        result +
        match value with 
        |"A X" -> 0 + 3 // 3
        |"A Y" -> 3 + 1 // 4
        |"A Z" -> 6 + 2 // 8
        |"B X" -> 0 + 1 // 1
        |"B Y" -> 3 + 2 // 5
        |"B Z" -> 6 + 3 // 9
        |"C X" -> 0 + 2 // 2
        |"C Y" -> 3 + 3 // 6
        |"C Z" -> 6 + 1 // 7
        |_ -> new Exception() |> raise

    let puzzle1 input = input |> Array.fold calcRound 0

    let puzzle2 input = input |> Array.fold calcRound2 0

    let Solution = (new Solution(2, puzzle1, puzzle2) :> ISolution).Execute