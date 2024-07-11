module WelcomePage

open Giraffe.ViewEngine

let greeting = System.Environment.GetEnvironmentVariable "GreetingName"

let welcomePage = 
  html
    [ _lang "en-US" ]
    [ 
      head [] [ title [] [ str "Welcome!" ] ]
      body [] [
        h1 [] [ sprintf "Welcome %s!" greeting |> str ] 
      ]
    ]


