namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day03

module Day03Tests =
    let testInput = 
        [|
        "vJrwpWtwJgWrhcsFMMfFFhFp"
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
        "PmmdzqPrVvPwwTWBwg"
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
        "ttgJtRGJQctTZtZT"
        "CrZsJsPPZsGzwwsLwLmpwMDw"
        |]  
    
    [<Fact>]
    let ``Day 3 Puzzle 1`` () =
        Assert.Equal(157, puzzle1 testInput)
    
    [<Fact>]
    let ``Day 3 Puzzle 2`` () =
        Assert.Equal(70, puzzle2 testInput)      