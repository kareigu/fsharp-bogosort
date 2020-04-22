open System

let rand = new System.Random()

let mutable iters : int = 0

let swap (arr: _[]) x y =
    let tmp = arr.[x]
    arr.[x] <- arr.[y]
    arr.[y] <- tmp

let shuffle sArray =
    Array.iteri (fun i _ -> swap sArray i (rand.Next(i, Array.length sArray))) sArray


let rec checkArray sorted sortResult =
    let sortStatus : bool = sorted = sortResult
    if sortStatus then
        sortResult
    else
        printfn"%A" sortResult
        iters <- iters + 1
        shuffle sortResult
        checkArray sorted sortResult


[<EntryPoint>]
let main argv =
    let arrayLength : int = 10
    let sortedArray : int array = [|for i in 1 .. arrayLength -> i |]
    let mutable arrayToSort : int array = Array.copy sortedArray
    shuffle arrayToSort

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    printfn"%A" (checkArray sortedArray arrayToSort)
    stopWatch.Stop()
    printf"Iterations: "
    printfn"%i" iters

    printf"Time to complete: "
    printfn"%fs" stopWatch.Elapsed.TotalSeconds
    0 // return an integer exit code