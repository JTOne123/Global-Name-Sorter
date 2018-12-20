
# Global X - Global Name Sorter


Badges

Screenshots

Pages: https://puzzleduck.github.io/Global-Name-Sorter/


## Project Structure

Library

CI

TDD & Tests


## Running the project



git clone
cd

dotnet build

dotnet run --project

tests

contrib



## Assumptions and Issues



## Plan

- [x] review challenge
- [x] plan approach
- [x] review GlobalX github repos for style/practices/project layout/etc
- [x] docs & github setup
- [x] setup wiki
- [x] GH Pages
- [x] Issue templates
- [x] Pull request template
- [x] initialise project
- [x] setup tests
- [x] semantic versioning
- [ ] setup CI
- [x] setup nuget deployment
- [ ] data models
- [ ] sort library
- [ ] integration tests
- [ ] program with no input
- [ ] program with simple inputs
- [ ] advanced inputs
- [ ] stress testing?
- [ ] add alternative CI platforms/providers?
- [ ] alternative interface?
- [ ] deployment/web interface?
- [ ] presentation?
- [ ] naming review
- [ ] SOLID review
- [ ] comment review
- [ ] readability review
- [ ] review c# conventions
- [ ] final review


## Source Code Review

Observations from reviewing GlobalX public repositories on GitHub. They are presented in approximate order I expect to emulate the good examples:

- [ ] top level Project & Project.Tests convention
- [x] include guides (user/dev) - readme.md/contributing.md
- [x] wiki
- [x] mit licence
- [x] CONTRIBUTING.md
- [ ] include examples /
- [ ] include demo
- [ ] include samples
- [ ] newbe/hackathon/low-hanging-fruit planning (multiple file arguments, output file specification, large files, ...)
- [ ] unit test project
- [ ] integration test project
- [ ] stress test project
- [ ] long and descriptive naming
- [ ] self documenting... comments usually explain "why" or "why not the usual/expected way"
- [ ] model / view separation
- [ ] validation and verbose error reporting
- [ ] nice .gitattributes
- [ ] honest about defects



## Problem Specification


GlobalX Coding Assessment
- [ ] how your code communicates it's purpose clearly and with empathy
- [ ] caring about how easy your code is to understand and navigate
- [ ] your ability to compose quality code that adheres to SOLID principles
- [ ] how you write tests.

- [ ] best effort
- [ ] a solution that you are proud of.

- [ ] Build a name sorter
- [ ] Given a set of names, order that set first by last name, then by any given names
- [ ] A name must have at least 1 given name and may have up to 3 given names.

## Example
- [ ] Given a a file called unsorted-names-list.txt containing the following list of names;

Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Leo Gardner
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter

- [ ] Executing the program in the following way;
name-sorter ./unsorted-names-list.txt

- [ ] Should result the sorted names to screen;

Marin Alvarez
Adonis Julius Archer
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Leo Gardner
Vaughn Lewis
London Lindsey
Mikayla Lopez
Janet Parsons
Frankie Conner Ritter
Shelby Nathan Yoder

- [ ] and a file in the working directory called sorted-names-list.txt containing the sorted names.

- [ ] a list with a thousand names.
- [ ] available for review on github.
- [ ] names should be sorted correctly.
- [ ] It should print the sorted list of names to screen.
- [ ] It should write/overwrite the sorted list of names to a file called sorted-names-list.txt.
- [ ] Unit tests
- [ ] practical documentation
- [ ] Create a build pipeline like Travis or AppVeyor that execute build and test
- [ ] let us know the url of the repo





