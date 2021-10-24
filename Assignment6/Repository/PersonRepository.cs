using Assignment6.Entities;
using Assignment6.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Repository
{
    public class PersonRepository : IProcessPerson
    {
        List<Person> personList = new List<Person>();
        
        //assuming 150 as the maximum value for the age
        int minAge = 150;
        int tempAge;

        public bool Add(Person person)
        {
            if (!personList.Any(p => p.EmailAddress== person.EmailAddress))
            {
                personList.Add(person);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool Delete(Person person)
        {
            int index = personList.FindIndex(x => x.EmailAddress == person.EmailAddress);
            
            if (index!=-1)
            {
                personList.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Person> GetAll()
        {
            return personList;
        }

        public List<Person> GetByName(string name)
        {
            return personList.FindAll(x => name == (x.FirstName + " " + x.LastName));
        }

        public int GetMinimumAge(string name)
        {
            List<Person> temp = personList.FindAll(x => name == (x.FirstName + " " + x.LastName));
            if(temp.Count>0)
            {
                
                Console.WriteLine(DateTime.Now.ToOADate());
                foreach (var o in temp)
                {
                    tempAge=(int)((DateTime.Now.ToOADate()-o.DateofBirth)/ 365.2422);
                    if (tempAge < minAge)
                        minAge = tempAge;
                }
                return minAge;
            }
            else
            {
                return -1;
            }

            

        }
    }


}
