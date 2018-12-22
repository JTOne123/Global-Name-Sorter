using NameSorter;
using Models;
using System.Collections.Generic;

namespace Sorters
{
    public interface ISorter
    {
        List<Person> sort_people(List<Person> unsorted_people);
    }
}
