using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Entities;

namespace Assignment6.Interface
{
    interface IProcessPerson
    {
        bool Add(Person person);

        bool Delete(Person person);

        List<Person> GetAll();

        List<Person> GetByName(string name);

        int GetMinimumAge(string Name);
    }
}
