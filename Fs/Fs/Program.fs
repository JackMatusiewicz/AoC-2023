namespace Fs

module Program =

    [<EntryPoint>]
    let main _ =
        printfn "%d" <| DayTwo.computePartTwo "Data\\DayTwoData.txt"
        0