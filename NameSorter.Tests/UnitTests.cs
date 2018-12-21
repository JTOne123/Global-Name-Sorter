using System;
using Xunit;
using Models;
using System.Collections.Generic;

namespace NameSorter.Tests
{
    public class UnitTests
    {
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
