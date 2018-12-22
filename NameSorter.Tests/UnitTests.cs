using System;
using Xunit;
using Models;
using System.Collections.Generic;
using Sorters;
using Formatters;

namespace NameSorter.Tests
{
    public class UnitTests
    {
        [Fact]
        public void NameSorterEOutputWithExample()
        {
            NameSort sorter = new NameSort();
            sorter.SetFormatModule(new PlainTextFormatter());
            sorter.SetSortModule(new LastNameAscendingSorter());
            sorter.AddPerson(new Person("Janet Parsons"));
            sorter.AddPerson(new Person("Vaughn Lewis"));
            sorter.AddPerson(new Person("Adonis Julius Archer"));
            sorter.AddPerson(new Person("Shelby Nathan Yoder"));
            sorter.AddPerson(new Person("Marin Alvarez"));
            sorter.AddPerson(new Person("London Lindsey"));
            sorter.AddPerson(new Person("Beau Tristan Bentley"));
            sorter.AddPerson(new Person("Leo Gardner"));
            sorter.AddPerson(new Person("Hunter Uriah Mathew Clarke"));
            sorter.AddPerson(new Person("Mikayla Lopez"));
            sorter.AddPerson(new Person("Frankie Conner Ritter"));
            sorter.SortPeople();
            Assert.Equal("Marin Alvarez\nAdonis Julius Archer\nBeau Tristan Bentley\nHunter Uriah Mathew Clarke\nLeo Gardner\nVaughn Lewis\nLondon Lindsey\nMikayla Lopez\nJanet Parsons\nFrankie Conner Ritter\nShelby Nathan Yoder\n", sorter.OutputString());
        }

        [Fact]
        public void NameSorterOutputWithUnorderedNames()
        {
            NameSort sorter = new NameSort();
            sorter.SetFormatModule(new PlainTextFormatter());
            sorter.SetSortModule(new LastNameAscendingSorter());
            sorter.AddPerson(new Person("Second SecondLast"));
            sorter.AddPerson(new Person("First Last"));
            sorter.SortPeople();
            Assert.Equal("First Last\nSecond SecondLast\n", sorter.OutputString());
        }

        [Fact]
        public void NameSorterFunctionsWithUnorderedNames()
        {
            NameSort sorter = new NameSort();
            sorter.SetFormatModule(new PlainTextFormatter());
            sorter.SetSortModule(new LastNameAscendingSorter());
            sorter.AddPerson(new Person("Second SecondLast"));
            sorter.AddPerson(new Person("First Last"));
            List<Person> sortedPeople = sorter.SortPeople();
            Assert.Equal("First Last", sortedPeople[0].GetFullName());
        }

        [Fact]
        public void NameSorterFunctionsWithSingleName()
        {
            NameSort sorter = new NameSort();
            sorter.SetFormatModule(new PlainTextFormatter());
            sorter.SetSortModule(new LastNameAscendingSorter());
            sorter.AddPerson(new Person("First Last"));
            List<Person> sortedPeople = sorter.SortPeople();
            Assert.Equal("First Last", sortedPeople[0].GetFullName());
        }

        [Fact]
        public void StringConstructorForTwoPartNames()
        {
            Person person = new Person("First Last");
            Assert.Equal("First Last", person.GetFullName());
        }

        [Fact]
        public void PersonLastNamesFunctionsAsExpected()
        {
            Person person = new Person();
            person.SetFirstNames("First");
            person.SetLastName("Last");
            Assert.Equal("First Last", person.GetFullName());
        }

        [Fact]
        public void PersonFirstNamesFunctionsAsExpected()
        {
            Person person = new Person();
            person.SetFirstNames("First", "Second", "Third");
            Assert.Equal("First Second Third", person.GetFullName());
        }

        [Fact]
        public void PersonFirstNameFunctionsAsExpected()
        {
            Person person = new Person();
            person.SetFirstNames("First");
            Assert.Equal("First", person.GetFullName());
        }

        [Fact]
        public void Tautology()
        {
            Assert.True(true);
        }
    }
}
