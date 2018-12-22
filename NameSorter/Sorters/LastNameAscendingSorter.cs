using NameSorter;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Sorters
{
    public class LastNameAscendingSorter : ISorter
    {
        public List<Person> SortPeople(List<Person> unsorted_people) {
          return unsorted_people.OrderBy(person => person.getOrderingName()).ToList();;
        }
    }
}
