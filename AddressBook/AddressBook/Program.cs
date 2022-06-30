using AddressBook;
internal class Program
{
    
    
    public static void Main(String[] args)
    {
        Console.WriteLine("-----------------------------------------------------\n1.Create Contact\n2.Edit Contact\n3.Delete Contact\n4.Display Contacts\n5.Add Multiple Contacts\n6.Add Multiple Address Books\n7.Search By City or State\n8.Display by city or State\n9.Count by city or state\n10.Read and Write From Txt File\n11.Read and Write From CSV File\n12.Read and Write from JSON File\n0.Exit\n");
        Console.WriteLine("Enter your choice:");
        int choice = Convert.ToInt32(Console.ReadLine());
        AddressBook.Person p = new AddressBook.Person();
        while (choice != 0)
        {
            Console.Clear();

            switch (choice)
            {
                case 1:
                    AddressBook.Person.createContacts();
                    break;
                case 2:
                    AddressBook.Person.editContacts();
                    break;
                case 3:
                    AddressBook.Person.removeContact();
                    break;
                case 4:
                    p.displayContacts();
                    break;
                case 5:
                    p.addMultiContacts();
                    break;
                case 6:
                    p.addMultiAddressBooks();
                    break;
                case 7:
                    p.SearchByCityorState();
                    break;
                case 8:
                    p.displayByCityOrState();
                    break;
                case 9:
                    p.getCount();
                    break;
                case 10:
                    p.writeToTxtFile();
                    p.readFromTxtFile();
                    break;
                case 11:
                    p.writeToCSVFile();
                    p.readFromCSVFile();
                    break;
                case 12:
                    p.JSONSerialization();
                    p.JSONDeserialization();
                    break;
                default:
                    Console.Write("Enter valid option.\n");
                    break;

            }
            Console.WriteLine("-----------------------------------------------------\n1.Create Contact\n2.Edit Contact\n3.Delete Contact\n4.Display Contacts\n5.Add Multiple Contacts\n6.Add Multiple Address Books\n7.Search By City or State\n8.Display by city or State\n9.Count by city or state\n10.Read and Write From Txt File\n11.Read and Write From CSV File\n12.Read and Write from JSON File\n0.Exit\n");
            Console.WriteLine("Enter your choice:");
            choice = Convert.ToInt32(Console.ReadLine());

        }
       
    }
}