#!/bin/sh

dotnet restore
dotnet pack -c Release
