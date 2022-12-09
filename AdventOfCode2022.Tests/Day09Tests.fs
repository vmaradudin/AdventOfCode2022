namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day09

module Day09Tests = 
    let input1 =
        [|
        "R 4"
        "U 4"
        "L 3"
        "D 1"
        "R 4"
        "D 1"
        "L 5"
        "R 2"
        |]

    let input2 =
        [|
        "R 5"
        "U 8"
        "L 8"
        "D 3"
        "R 17"
        "D 10"
        "L 25"
        "U 20"
        |]

    [<Fact>]
    let ``Day 9 Puzzle 1`` () =
        Assert.Equal(13, puzzle1 input1)
    
    [<Fact>]
    let ``Day 9 Puzzle 2`` () =
        Assert.Equal(1, puzzle2 input1)
        Assert.Equal(36, puzzle2 input2)