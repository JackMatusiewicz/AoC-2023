namespace Fs

module Program =

    [<EntryPoint>]
    let main _ =
        printfn "%d" <| DayTwo.computePartOne "Data\\DayTwoData.txt"
        0