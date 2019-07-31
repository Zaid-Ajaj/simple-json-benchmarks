module App

open Fable.SimpleJson
open Fable.Mocha
open Node

let historyJson = path.resolve(path.join(__SOURCE_DIRECTORY__, "history.json"))

let benchmarks =
    testList "Json tests" [
        testCase "Reading file contents" <| fun _ ->
            let contents = fs.readFileSync(historyJson, "utf8")
            let deserialized = Json.parseNativeAs<{| field: int  |}> contents
            Expect.equal deserialized.field 1 "Deserialized correctly"
    ]

[<EntryPoint>]
let main args = Mocha.runTests benchmarks