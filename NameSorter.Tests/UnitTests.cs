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
            sorter.set_format_module(new PlainTextFormatter());
            sorter.set_sort_module(new LastNameAscendingSorter());
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
            Assert.Equal("Marin Alvarez\nAdonis Julius Archer\nBeau Tristan Bentley\nHunter Uriah Mathew Clarke\nLeo Gardner\nVaughn Lewis\nLondon Lindsey\nMikayla Lopez\nJanet Parsons\nFrankie Conner Ritter\nShelby Nathan Yoder\n", sorter.outputString());
        }

        [Fact]
        public void NameSorterOutputWithUnorderedNames()
        {
            NameSort sorter = new NameSort();
            sorter.set_format_module(new PlainTextFormatter());
            sorter.set_sort_module(new LastNameAscendingSorter());
            sorter.AddPerson(new Person("Second SecondLast"));
            sorter.AddPerson(new Person("First Last"));
            sorter.SortPeople();
            Assert.Equal("First Last\nSecond SecondLast\n", sorter.outputString());
        }

        [Fact]
        public void NameSorterFunctionsWithUnorderedNames()
        {
            Person firstPerson = new Person("First Last");
            Person secondPerson = new Person("Second SecondLast");
            NameSort sorter = new NameSort();
            sorter.set_format_module(new PlainTextFormatter());
            sorter.set_sort_module(new LastNameAscendingSorter());
            sorter.AddPerson(secondPerson);
            sorter.AddPerson(firstPerson);
            List<Person> sortedPeople = sorter.SortPeople();
            Assert.Equal("First Last", sortedPeople[0].getFullName());
        }

        [Fact]
        public void NameSorterFunctionsWithSingleName()
        {
            Person person = new Person("First Last");
            NameSort sorter = new NameSort();
            sorter.set_format_module(new PlainTextFormatter());
            sorter.set_sort_module(new LastNameAscendingSorter());
            sorter.AddPerson(person);
            List<Person> sortedPeople = sorter.SortPeople();
            Assert.Equal("First Last", sortedPeople[0].getFullName());
        }

        [Fact]
        public void StringConstructorForTwoPartNames()
        {
            Person person = new Person("First Last");
            Assert.Equal("First Last", person.getFullName());
        }

        [Fact]
        public void PersonLastNamesFunctionsAsExpected()
        {
            Person person = new Person();
            person.setFirstNames("First");
            person.setLastName("Last");
            Assert.Equal("First Last", person.getFullName());
        }

        [Fact]
        public void PersonFirstNamesFunctionsAsExpected()
        {
            Person person = new Person();
            person.setFirstNames("First", "Second", "Third");
            Assert.Equal("First Second Third", person.getFullName());
        }

        [Fact]
        public void PersonFirstNameFunctionsAsExpected()
        {
            Person person = new Person();
            person.setFirstNames("First");
            Assert.Equal("First", person.getFullName());
        }

        [Fact]
        public void Tautology()
        {
            Assert.True(true);
        }
    }
}
