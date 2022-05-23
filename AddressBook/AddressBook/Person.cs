using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Person
    {
        public static void createContacts()
        {
            Contacts contact = new Contacts();
            Console.WriteLine("Enter First Name: ");
            contact.fName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            contact.lName = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            contact.phoneNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Address: ");
            contact.address = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            contact.city = Console.ReadLine();

            Console.WriteLine("Enter Zip: ");
            contact.zip = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter State: ");
            contact.state = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            contact.email = Console.ReadLine();

            Directory.person.Add(contact);
        }
    }
}
