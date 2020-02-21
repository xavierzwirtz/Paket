module Paket.IntegrationTests.ResolvePackageUrlSpecs

open Fake
open System
open NUnit.Framework
open FsUnit
open System
open System.IO
open System.IO.Compression
open System.Diagnostics
open Paket
open Paket.Domain

[<Test>]
let ``resolve nuget v2``() =
    let scenario = "empty"
    use __ = prepare scenario
    let url = directPaket "resolve-package-url Newtonsoft.Json --version 12.0.3 --silent --source https://www.nuget.org/api/v2 --force" scenario

    url |> shouldEqual "https://www.nuget.org/api/v2/package/Newtonsoft.Json/12.0.3"

[<Test>]
let ``resolve nuget v3``() =
    let scenario = "empty"
    use __ = prepare scenario
    let url = directPaket "resolve-package-url Newtonsoft.Json --version 12.0.3 --silent --source https://api.nuget.org/v3/index.json --force" scenario

    url |> shouldEqual "https://api.nuget.org/v3-flatcontainer/newtonsoft.json/12.0.3/newtonsoft.json.12.0.3.nupkg"

[<Test>]
let ``resolve myget``() =
    let scenario = "empty"
    use __ = prepare scenario
    let url = directPaket "resolve-package-url System.Text.Encoding.CodePages --version 4.6.0-preview3-26501-04 --silent --source https://dotnet.myget.org/F/dotnet-core/api/v3/index.json --force" scenario

    url |> shouldEqual "https://dotnet.myget.org/F/dotnet-core/api/v2/package/System.Text.Encoding.CodePages/4.6.0-preview3-26501-04"
