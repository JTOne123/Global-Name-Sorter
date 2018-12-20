using System;
using Xunit;

namespace NameSorter.Tests
{
    public class UnitTests
    {
        [Fact]
        public void PersonFirstNameFunctionsAsExpected()
        {
            Person person = new Person();
            person.setFirstName("First");
            Assert.Equal("First", person.getFullName());
        }

        [Fact]
        public void Tautology()
        {
            Assert.True(true);
        }
    }
}
