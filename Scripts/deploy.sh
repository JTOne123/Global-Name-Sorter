#!/bin/sh

dotnet pack -c Release
dotnet nuget push --source https://www.nuget.org --api-key $NUGET_API_KEY GlobalNameSorter/nupkg/*.nupkg || true
dotnet nuget push --source https://www.nuget.org --api-key $NUGET_API_KEY NameSorter/bin/Release/*.nupkg || true
