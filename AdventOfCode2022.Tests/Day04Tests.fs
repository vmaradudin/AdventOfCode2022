namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day04

module Day04Tests =
    let testInput = 
        [|
        "2-4,6-8"
        "2-3,4-5"
        "5-7,7-9"
        "2-8,3-7"
        "6-6,4-6"
        "2-6,4-8"
        |]  
    
    [<Fact>]
    let ``Day 4 Puzzle 1`` () =
        Assert.Equal(2, puzzle1 testInput)
    
    [<Fact>]
    let ``Day 4 Puzzle 2`` () =
        Assert.Equal(4, puzzle2 testInput)      