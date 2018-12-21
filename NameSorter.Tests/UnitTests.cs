using System;
using Xunit;
using Models;

namespace NameSorter.Tests
{
    public class UnitTests
    {
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
