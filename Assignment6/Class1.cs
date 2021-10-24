using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Interface;
using Assignment6.Repository;

namespace Assignment6
{
    public class Class1
    {
        static void Main()
        {
            IProcessPerson personRepoObj = new PersonRepository();

            DateTime DOB = new DateTime(1996, 02, 09);

            

            string FirstName = "Nagalakshmi";
            string LastName = "Vaduganathan";
            string EmailAddress = "nagalakshmi.v@vernal.is";
            double DateofBirth = DOB.ToOADate();

            
            //adding New Person
            Console.WriteLine(personRepoObj.Add(new Entities.Person { FirstName = FirstName, LastName=LastName, EmailAddress=EmailAddress, DateofBirth=DateofBirth+1000 }));
            Console.WriteLine(personRepoObj.Add(new Entities.Person { FirstName = FirstName, LastName = LastName, EmailAddress = "nagalakshmi@vernal.is", DateofBirth = DateofBirth }));

            Console.WriteLine(personRepoObj.Add(new Entities.Person { FirstName = "Harish", LastName = "Ramesh", EmailAddress = "harish@vernal.is", DateofBirth = DateofBirth }));


            //Console.WriteLine(personRepoObj.Delete(new Entities.Person { FirstName = FirstName, LastName = LastName, EmailAddress = EmailAddress, DateofBirth = DateofBirth }));
            Console.WriteLine(personRepoObj.Delete(new Entities.Person { FirstName = "Harish", LastName = "Ramesh", EmailAddress = "harish@vernal.is", DateofBirth = DateofBirth }));

            var userList = personRepoObj.GetAll();

            if(userList.Count>0)
            {
                foreach(var o in userList)
                {
                    Console.WriteLine("{0},{1},{2},{3}", o.FirstName, o.LastName, o.EmailAddress, DateTime.FromOADate(o.DateofBirth).ToShortDateString());
                }
            }
            else
            {
                Console.WriteLine("No User Details Available");
            }

            Console.WriteLine("\n-----------Fetching user details with the name Nagalakshmi Vaduganathan-----------\n");
            var nameList = personRepoObj.GetByName("Nagalakshmi Vaduganathan");
            if (nameList.Count > 0)
            {
                foreach (var o in userList)
                {
                    Console.WriteLine("{0},{1},{2},{3}", o.FirstName, o.LastName, o.EmailAddress, DateTime.FromOADate(o.DateofBirth).ToShortDateString());
                }
            }
            else
            {
                Console.WriteLine("No User Details Available");
            }

            Console.WriteLine("\n-----------Fetching min age for the name Nagalakshmi Vaduganathan-----------\n");

            int age = personRepoObj.GetMinimumAge("Nagalakshmi Vaduganathan");

            if(age!=-1)
            {
                Console.WriteLine(age);
            }
            else
            {
                Console.WriteLine("No User Details Available for the given name");
            }

            Console.Read();
        }
    }
}
