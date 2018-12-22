#!/bin/sh

cd NameSorter.Tests
dotnet test /p:CollectCoverage=true
cd ..
