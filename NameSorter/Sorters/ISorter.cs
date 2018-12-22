using NameSorter;
using Models;
using System.Collections.Generic;

namespace Sorters
{
    // The ISorter module provides an interface for sorting the NameSorter data
    public interface ISorter
    {
        List<Person> SortPeople(List<Person> unsorted_people);
    }
}
