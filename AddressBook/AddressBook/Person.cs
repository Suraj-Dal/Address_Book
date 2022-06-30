using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Person
    {
        public static List<Contacts> person = new List<Contacts>();
        public Dictionary<string, List<Contacts>> group = new Dictionary<string, List<Contacts>>();
        public Dictionary<string, List<string>> byCity = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> ByState = new Dictionary<string, List<string>>();

        public static void createContacts()
        {

            Contacts contact = new Contacts();
            Console.WriteLine("Enter First Name: ");
            contact.fName = Console.ReadLine();
            Contacts contacts = person.FirstOrDefault(p => p.Equals(contact));
            if (contacts == null)
            {
                Console.WriteLine("Enter Last Name: ");
                contact.lName = Console.ReadLine();

                Console.WriteLine("Enter Phone Number: ");
                contact.phoneNo = Convert.ToDouble(Console.ReadLine());

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

                person.Add(contact);
            }
            else
                Console.WriteLine("Contact already exist in address book.\n");

        }

        public void displayContacts()
        {
            if (person.Count == 0)
            {
                Console.WriteLine("Address book is empty.");
                return;
            }

            Console.WriteLine("1.Total Contacts\n2.Group");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("List of contacts:\n");
                    foreach (string key in group.Keys)
                    {
                        List<Contacts> contacts = group[key];
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine("\nFirst Name: " + contact.fName + "\nLast Name: " + contact.lName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZip Code: " + contact.zip + "\nContact No.: " + contact.phoneNo + "\nEmail address: " + contact.email + "----------------------------------------------\n");
                        }
                    }
                    break;
                case 2:
                    foreach (string key in group.Keys)
                    {
                        Console.WriteLine(key);
                    }


                    Console.WriteLine("Enter group you want to display.");
                    string gName = Console.ReadLine();
                    List<Contacts> list = group[gName];

                    foreach (var contact in list)
                        Console.WriteLine("\nFirst Name: " + contact.fName + "\nLast Name: " + contact.lName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZip Code: " + contact.zip + "\nContact No.: " + contact.phoneNo + "\nEmail address: " + contact.email + "----------------------------------------------\n");
                    break;
            }

        }
        public static void editContacts()
        {
            Console.WriteLine("Enter Name of person to edit details: ");
            string name = Console.ReadLine();

            foreach (var contact in person)
            {
                if (contact.fName.Equals(name))
                {
                    Console.WriteLine("Which field you want to edit:\n1.First Name\n2.last Name\n3.Address\n4.city\n5.state\n6.zip\n7.Phone No.\n8.Email");
                    Console.WriteLine("Enter your choice:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter First Name to update:");
                            contact.fName = Convert.ToString(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name to update:");
                            contact.lName = Convert.ToString(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter Address to update:");
                            contact.address = Convert.ToString(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter City to update:");
                            contact.city = Convert.ToString(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Enter State to update:");
                            contact.state = Convert.ToString(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Enter Zip code to update:");
                            contact.zip = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Enter Phone to update:");
                            contact.phoneNo = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter Email to update:");
                            contact.email = Convert.ToString(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Invalid option:");
                            break;
                    }
                }
            }

        }
        public static void removeContact()
        {
            Console.WriteLine("Enter Name of person to delete details: ");
            string name = Console.ReadLine();

            foreach (var contact in person.ToList())
            {
                if (contact.fName.Equals(name))
                {
                    person.Remove(contact);
                }
            }
        }
        public void addMultiContacts()
        {
            Console.WriteLine("How many contacts you want to add:");
            int n = Convert.ToInt32(Console.ReadLine());
            person = new List<Contacts>();
            while (n > 0)
            {
                createContacts();
                n--;
            }

        }
        public void addMultiAddressBooks()
        {
            Console.WriteLine("How many address books you want to add: ");
            int noOfBooks = Convert.ToInt32(Console.ReadLine());
            while (noOfBooks > 0)
            {
                Console.WriteLine("Enter group name:");
                string gName = Console.ReadLine();
                addMultiContacts();
                group.Add(gName, person.ToList());
                noOfBooks--;
            }
        }
        public void SearchByCityorState()
        {
            Console.WriteLine("Enter City or state to search contacts:");
            string value = Console.ReadLine();
            foreach (var Contacts in group.Values)
            {
                List<Contacts> city = Contacts.FindAll(p => p.city.ToLower() == value.ToLower());
                List<Contacts> state = Contacts.FindAll(p => p.state.ToLower() == value.ToLower());
                if (city.Count != 0)
                {
                    Console.WriteLine("All contacts from city {0} are:", value);
                    foreach (var contact in city)
                    {
                        Console.WriteLine("Name:{0} {1}", contact.fName, contact.lName);
                    }
                }
                else if (state.Count != 0)
                {
                    Console.WriteLine("All contacts from state {0} are:", value);
                    foreach (var contact in state)
                    {
                        Console.WriteLine("Name:{0} {1}", contact.fName, contact.lName);
                    }
                }
                else
                    Console.WriteLine("No contact details availbale for given city/State.");
            }

        }
        public void displayByCityOrState()
        {
            foreach (var key in group.Keys)
            {
                foreach (var item in group[key])
                {

                    if (byCity.ContainsKey(item.city))
                        byCity[item.city].Add(item.fName + " " + item.lName);
                    else
                        byCity.Add(item.city, new List<string>() { item.fName + " " + item.lName });
                    if (ByState.ContainsKey(item.state))
                        ByState[item.state].Add(item.fName + " " + item.lName);
                    else
                        ByState.Add(item.state, new List<string>() { item.fName + " " + item.lName });
                }
            }
            Console.WriteLine("Contacts by city:");
            foreach (var key in byCity.Keys)
            {
                Console.WriteLine("Contacts from city:" + key);
                byCity[key].ForEach(x => Console.WriteLine(x));

            }
            Console.WriteLine("Contacts by state:");
            foreach (var key in ByState.Keys)
            {
                Console.WriteLine("Contacts from state: " + key);
                ByState[key].ForEach(x => Console.WriteLine(x));
            }
        }
        public void getCount()
        {
            foreach (var key in group.Keys)
            {
                foreach (var item in group[key])
                {

                    if (byCity.ContainsKey(item.city))
                        byCity[item.city].Add(item.fName + " " + item.lName);
                    else
                        byCity.Add(item.city, new List<string>() { item.fName + " " + item.lName });
                    if (ByState.ContainsKey(item.state))
                        ByState[item.state].Add(item.fName + " " + item.lName);
                    else
                        ByState.Add(item.state, new List<string>() { item.fName + " " + item.lName });
                }
            }
            Console.WriteLine("No. of contacts by city.");
            foreach (var key in byCity.Keys)
            {
                    Func<int, int> count = x =>
                    {
                        foreach (var value in byCity[key])
                            x += 1;
                        return x;
                    };
                    Console.WriteLine("No. of contacts in city " + key + " are " + count(0));
            }
            Console.WriteLine("No. of contacts by state.");
            foreach (var key in ByState.Keys)
            {
                    Func<int, int> count = x =>
                    {
                        foreach (var value in ByState[key])
                            x += 1;
                        return x;
                    };
                    Console.WriteLine("No. of contacts in state " + key + " are " + count(0));
            }

        }

        public void writeToTxtFile()
        {
            string path = @"C:\Projects\Address_Book\ContactsFile.txt";
            Console.WriteLine("FirstName, LastName, Address, City, Zip, Phone, Email (Use ',' as seperator)");
            using StreamWriter write = new StreamWriter(path);
            {
                write.WriteLine(Console.ReadLine());
                write.Close();
            }
        }

        public void readFromTxtFile()
        {
            string path = @"C:\Projects\Address_Book\ContactsFile.txt";
            string[] data = File.ReadAllLines(path);
            string[] header = { "First Name", "LastName", "Address", "City", "State", "Zip Code", "Phone Number", "Email" };

            for (int i = 0; i < data.Length; i++)
            {
                string[] person = data[i].Split(","); 
                for (int j = 0; j < person.Length; j++)
                {
                    Console.WriteLine(header[j] +":"+ person[j]);
                }
            }
        }

        public void writeToCSVFile()
        {
            string path = @"C:\Projects\Address_Book\ContactsCSV.csv";
            Console.WriteLine("FirstName, LastName, Address, City, Zip, Phone, Email (Use ',' as seperator)");
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Console.ReadLine());
            File.AppendAllText(path, builder.ToString());
        }

        public void readFromCSVFile()
        {
            string path = @"C:\Projects\Address_Book\ContactsCSV.csv";
            string[] data = File.ReadAllLines(path);
            string[] header = { "First Name", "LastName", "Address", "City", "State", "Zip Code", "Phone Number", "Email" };

            for (int i = 0; i < data.Length; i++)
            {
                string[] person = data[i].Split(",");
                for (int j = 0; j < person.Length; j++)
                {
                    Console.WriteLine(header[j] + ":" + person[j]);
                }
            }
        }

        public void JSONSerialization()
        {
            String path = @"C:\Projects\Address_Book\ContactsJSON.json";
            addMultiAddressBooks();
            var json = JsonConvert.SerializeObject(group);
            File.WriteAllText(path, json);
        }

        public void JSONDeserialization()
        {
            String path = @"C:\Projects\Address_Book\ContactsJSON.json";
            using StreamReader streamReader = new StreamReader(path);
            {
                string json = streamReader.ReadToEnd();
                var jsonfile = JsonConvert.DeserializeObject<Dictionary<string, List<Contacts>>>(json);
                foreach (var detail in jsonfile)
                {
                    foreach (var data in detail.Value)
                    {
                        Console.WriteLine("First Name: " + data.fName + "\nLast Name: " + data.lName + "\nAddress: "
                        + data.address + "\nCity: " + data.city + "\nState: " + data.state + "\nZip Code: "
                        + data.zip + "\nPhone Number: " + data.phoneNo + "\nEmail: " + data.email + "\n");
                    }
                }
            }
        }
    }
}

