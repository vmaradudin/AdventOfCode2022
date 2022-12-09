namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day08

module Day08Tests = 
    let input =
        [|
        "30373"
        "25512"
        "65332"
        "33549"
        "35390"
        |]

    [<Fact>]
    let ``Day 8 Puzzle 1`` () =
        Assert.Equal(21, puzzle1 input)
    
    [<Fact>]
    let ``Day 8 Puzzle 2`` () =
        Assert.Equal(8, puzzle2 input)