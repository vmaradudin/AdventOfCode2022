namespace AdventOfCode2022

open Common.Types

module Day09 =
    let pullKnot (prevKnotX,prevKnotY) (knotX, knotY)=
        let xDistance = prevKnotX - knotX
        let yDistance = prevKnotY - knotY
        let moveRequired = abs(xDistance) > 1 || abs(yDistance) > 1
        let moveX = moveRequired && xDistance <> 0
        let moveY = moveRequired && yDistance <> 0
        let newKnotX = knotX + if moveX then xDistance/abs(xDistance) else 0
        let newKnotY = knotY + if moveY then yDistance/abs(yDistance) else 0
        (newKnotX, newKnotY)

    let pullRopeHead direction (headX,headY) =
        match direction with
        | "R" -> headX + 1, headY
        | "L" -> headX - 1, headY
        | "U" -> headX, headY + 1
        | "D" -> headX, headY - 1

    let pullRopeKnot rope theKnot =
        let lastKnot = rope |> Seq.last
        let newKnot = pullKnot lastKnot theKnot
        Seq.append rope (seq{newKnot})

    let rec pullRope (rope, trackOflastKnot) (direction, moves) =
        match moves with
        | 0 -> rope,trackOflastKnot
        | _ ->
        let newHead = rope |> Seq.head |> pullRopeHead direction
        let newRope = rope |> Seq.tail |> Seq.fold pullRopeKnot (seq{newHead})
        let newTrack = trackOflastKnot |> Set.add (newRope |> Seq.last)
        pullRope (newRope, newTrack) (direction, (moves - 1))

    let rope length = seq{for i in 1..length -> 0,0}

    let instructions (input:string[]) = input |> Array.map (fun a -> a.Split(" ") |>fun s -> (s[0], (s[1] |> int))) |> Seq.ofArray
    
    let getTailTrace ropeLength input = input |> instructions |> Seq.fold pullRope ((rope ropeLength),(Set.empty.Add((0,0)))) |> snd |> Set.count
    

    let puzzle1 input = input |> getTailTrace 2
        
    let puzzle2 input = input |> getTailTrace 10


    let Solution = (new Solution(9, puzzle1, puzzle2) :> ISolution).Execute