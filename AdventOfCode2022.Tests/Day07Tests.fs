namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day07

module Day07Tests = 
    let input =
        [|
        "$ cd /"
        "$ ls"
        "dir a"
        "14848514 b.txt"
        "8504156 c.dat"
        "dir d"
        "$ cd a"
        "$ ls"
        "dir e"
        "29116 f"
        "2557 g"
        "62596 h.lst"
        "$ cd e"
        "$ ls"
        "584 i"
        "$ cd .."
        "$ cd .."
        "$ cd d"
        "$ ls"
        "4060174 j"
        "8033020 d.log"
        "5626152 d.ext"
        "7214296 k"
        |]

    [<Fact>]
    let ``Day 7 Puzzle 1`` () =
        Assert.Equal(95437L, puzzle1 input)
    
    [<Fact>]
    let ``Day 7 Puzzle 2`` () =
        Assert.Equal(24933642L, puzzle2 input)