﻿namespace Fs

open System
open System.IO

module DayTwo =

    // 12 red cubes, 13 green cubes, and 14 blue cubes
    let providedBag = Map.empty |> Map.add "blue" 14 |> Map.add "green" 13 |> Map.add "red" 12

    let parseBags (fileName: string) : string list list =
        File.ReadAllLines fileName
        |> List.ofArray
        |> List.map (fun s -> s.Split(":")[1])
        |> List.map (fun s -> s.Split(";") |> List.ofArray)

    let parseRound (round : string) : Map<string, int> =
        round.Split(',')
        |> Array.map (fun s ->
            let v = s.Trim()
            v.Split(' '))
        |> Array.map (fun v -> v[1], Int32.Parse(v[0]))
        |> Array.fold (fun m (k,v) -> Map.add k v m) Map.empty

    let isPossibleRound (round : Map<string, int>) : bool =
        round
        |> Map.fold (fun b k v -> b && (Map.find k providedBag) >= v) true

    let computePartOne (fileName: string) : int =
        parseBags fileName
        |> List.map (List.map parseRound)
        |> List.map (List.map isPossibleRound)
        |> List.map (List.fold (&&) true)
        |> List.mapi (fun i v -> (i+1, v))
        |> List.filter snd
        |> List.map fst
        |> List.sum

    let attemptUpdate (existing: Map<string, int>) k v =
        if not <| Map.containsKey k existing then
            Map.add k v existing
        else
            Map.add k (max v (Map.find k existing)) existing

    let condenseMaps (maps : Map<string, int> list) : Map<string, int> =
        List.fold (Map.fold attemptUpdate) Map.empty maps

    let computePower (map : Map<string, int>) : int =
        Map.fold (fun s _ v -> s * v) 1 map

    let computePartTwo (fileName: string) : int =
        parseBags fileName
        |> List.map (List.map parseRound)
        |> List.map condenseMaps
        |> List.map computePower
        |> List.sum
        