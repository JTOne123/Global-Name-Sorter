using System;
using Xunit;
using Models;
using System.Collections.Generic;

namespace NameSorter.Tests
{
    public class UnitTests
    {
        [Fact]
        public void NameSorterEOutputWithExample()
        {
            NameSorter sorter = new NameSorter();
            sorter.addPerson(new Person("Janet Parsons"));
            sorter.addPerson(new Person("Vaughn Lewis"));
            sorter.addPerson(new Person("Adonis Julius Archer"));
            sorter.addPerson(new Person("Shelby Nathan Yoder"));
            sorter.addPerson(new Person("Marin Alvarez"));
            sorter.addPerson(new Person("London Lindsey"));
            sorter.addPerson(new Person("Beau Tristan Bentley"));
            sorter.addPerson(new Person("Leo Gardner"));
            sorter.addPerson(new Person("Hunter Uriah Mathew Clarke"));
            sorter.addPerson(new Person("Mikayla Lopez"));
            sorter.addPerson(new Person("Frankie Conner Ritter"));
            sorter.sortPeople();
            Assert.Equal("Marin Alvarez\nAdonis Julius Archer\nBeau Tristan Bentley\nHunter Uriah Mathew Clarke\nLeo Gardner\nVaughn Lewis\nLondon Lindsey\nMikayla Lopez\nJanet Parsons\nFrankie Conner Ritter\nShelby Nathan Yoder\n", sorter.outputString());
        }

        [Fact]
        public void NameSorterOutputWithUnorderedNames()
        {
            NameSorter sorter = new NameSorter();
            sorter.addPerson(new Person("Second SecondLast"));
            sorter.addPerson(new Person("First Last"));
            sorter.sortPeople();
            Assert.Equal("First Last\nSecond SecondLast\n", sorter.outputString());
        }

        [Fact]
        public void NameSorterFunctionsWithUnorderedNames()
        {
            Person firstPerson = new Person("First Last");
            Person secondPerson = new Person("Second SecondLast");
            NameSorter sorter = new NameSorter();
            sorter.addPerson(secondPerson);
            sorter.addPerson(firstPerson);
            List<Person> sortedPeople = sorter.sortPeople();
            Assert.Equal("First Last", sortedPeople[0].getFullName());
        }

        [Fact]
        public void NameSorterFunctionsWithSingleName()
        {
            Person person = new Person("First Last");
            NameSorter sorter = new NameSorter();
            sorter.addPerson(person);
            List<Person> sortedPeople = sorter.sortPeople();
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
