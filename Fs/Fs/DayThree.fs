namespace Fs

open System
open System.IO

type Item =
    | Symbol of (int * int)
    | Number of (int * (int * int) * (int * int))

module DayThree =

    let private isDigit (c : char) : bool =
        c >= '0' && c <= '9'

    let parseLine (lineNumber: int) (line: string) : Item list =
        let rec go (currentNumber: int option) (start_position: (int * int) option) (pos: int) (acc : Item list) =
            if pos >= line.Length then
                match currentNumber, start_position with
                | Some v, Some sp -> Number (v, sp, (lineNumber, pos - 1))::acc
                | _ -> acc
            else if not <| isDigit line[pos] then
                let acc = 
                    match currentNumber, start_position with
                    | Some v, Some sp -> (Number (v, sp, (lineNumber, pos - 1))::acc)
                    | _ -> acc
                    |> fun acc -> if line[pos] <> '.' then Symbol(lineNumber, pos)::acc else acc
                go None None (pos+1) acc
            else
                let digitValue = int line[pos] - int '0'
                match currentNumber with
                | None -> go (Some digitValue) (Some (lineNumber, pos)) (pos + 1) acc
                | Some v -> go (Some <| v*10 + digitValue) start_position (pos+1) acc
                    
        go None None 0 []

    let computePartOne (fileName: string) =
        let items =
            File.ReadAllLines fileName
            |> List.ofArray
            |> List.mapi parseLine
            |> List.concat
        0