namespace Fs

module Program =

    [<EntryPoint>]
    let main _ =
        printfn "%d" <| DayThree.computePartOne "Data\\DayThreeData.txt"
        0