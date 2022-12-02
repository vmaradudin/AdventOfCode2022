namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day02

module Day02Tests =
    let testInput = 
        [|
          "A Y"
          "B X"
          "C Z"
        |]  
    
    [<Fact>]
    let ``Day 1 Puzzle 1`` () =
        Assert.Equal(15, puzzle1 testInput)
    
    [<Fact>]
    let ``Day 1 Puzzle 2`` () =
        Assert.Equal(12, puzzle2 testInput)      