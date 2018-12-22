using NameSorter;
using Models;
using System.Collections.Generic;

namespace Formatters
{
    public interface IFormatter
    {
        string FormatOutput(List<Person> people);
    }
}
