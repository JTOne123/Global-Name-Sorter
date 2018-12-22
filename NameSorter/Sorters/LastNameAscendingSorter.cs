using NameSorter;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Sorters
{
    // LastNameAscendingSorter provides a default sorting interface for the NameSorter program
    public class LastNameAscendingSorter : ISorter
    {
        public List<Person> SortPeople(List<Person> unsorted_people)
        {
          return unsorted_people.OrderBy(person => person.getOrderingName()).ToList();;
        }
    }
}
