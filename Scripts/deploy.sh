#!/bin/sh

dotnet pack -c Release
dotnet nuget push --source https://www.nuget.org --api-key $NUGET_API_KEY Service/bin/Release/*
