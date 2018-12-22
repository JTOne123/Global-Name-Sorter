using NameSorter;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Sorters
{
    public class LastNameAscendingSorter : ISorter
    {
        public List<Person> sort_people(List<Person> unsorted_people) {
          return unsorted_people.OrderBy(person => person.getOrderingName()).ToList();;
        }
    }
}
