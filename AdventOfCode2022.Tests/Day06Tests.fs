namespace AdventOfCode2022.Tests

open Xunit
open AdventOfCode2022.Day06

module Day06Tests =    
    [<Theory>]
    [<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)>]
    [<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)>]
    [<InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)>]
    [<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)>]
    [<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)>]
    let ``Day 6 Puzzle 1`` (input, expectedLength) =
        Assert.Equal(expectedLength, puzzle1 [|input|])
    
    [<Theory>]
    [<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)>]
    [<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)>]
    [<InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)>]
    [<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)>]
    [<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)>]
    let ``Day 6 Puzzle 2`` (input, expectedLength) =
        Assert.Equal(expectedLength, puzzle2 [|input|])      