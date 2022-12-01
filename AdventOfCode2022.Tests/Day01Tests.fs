namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day01

module Day01Tests =
    let testInput = 
        [|
          "1000"
          "2000"
          "3000"
          ""
          "4000"
          ""
          "5000"
          "6000"
          ""
          "7000"
          "8000"
          "9000"
          ""
          "10000"
        |]  
    
    [<Fact>]
    let ``Day 1 Puzzle 1`` () =
        Assert.Equal(24000, puzzle1 testInput)
    
    [<Fact>]
    let ``Day 1 Puzzle 2`` () =
        Assert.Equal(45000, puzzle2 testInput)      