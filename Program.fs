open System

[<EntryPoint>]
let main argv =

  let mutable number = 1

  for i in 1..10 do
    number <- number + number
    printfn "%d" number
  0 // return an integer exit code
