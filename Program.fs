open System
open System.Threading

let rec factorial n =
    try
        if n <= 1 then
            1
        else
            n * factorial (n - 1)
//    with
//    | Failure (msg) ->
//        printfn "overflowed %s" msg
//        n
    finally
        printfn "at the time of failure, n was %d" n


let main2 args =
    let result = factorial 261976

    Console.Write $"Factorial result : %d{result}"

[<STAThread>]
[<EntryPoint>]
let main args =
    let thread =
        new Thread((new ParameterizedThreadStart(main2)), 16 * 1024 * 1024)

    thread.SetApartmentState(ApartmentState.Unknown)
    thread.Start()
    thread.Join()
    0

(*
When the end condition is met -
we have a stack with the following variables,
the latest at the top.
n=1
n=2
n=3
n=4
n=5
*)

// popping the stack

(*
n=1,result = 1
n=2
n=3
n=4
n=5
*)

(*
n=2,result = 2
n=3
n=4
n=5
*)

(*
n=3,result = 6
n=4
n=5
*)

(*
n=4,result = 24
n=5
*)

(*
n=5,result = 120
*)
