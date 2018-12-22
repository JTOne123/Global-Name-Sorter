using NameSorter;
using Models;
using System.Collections.Generic;

namespace Formatters
{
    public interface IFormatter
    {
        string format_output(List<Person> people);
    }
}
