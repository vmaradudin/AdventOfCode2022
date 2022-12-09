namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day05

module Day05Tests =
    let testInput = 
        [|
        "    [D]    "
        "[N] [C]    "
        "[Z] [M] [P]"
        " 1   2   3 "
        ""
        "move 1 from 2 to 1"
        "move 3 from 1 to 3"
        "move 2 from 2 to 1"
        "move 1 from 1 to 2"
        |]
    
    [<Fact>]
    let ``Day 5 Puzzle 1`` () =
        Assert.Equal("CMZ", puzzle1 testInput)
    
    [<Fact>]
    let ``Day 5 Puzzle 2`` () =
        Assert.Equal("MCD", puzzle2 testInput)