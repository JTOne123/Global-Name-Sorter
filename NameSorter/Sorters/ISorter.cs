using NameSorter;
using Models;
using System.Collections.Generic;

namespace Sorters
{
    public interface ISorter
    {
        List<Person> SortPeople(List<Person> unsorted_people);
    }
}
