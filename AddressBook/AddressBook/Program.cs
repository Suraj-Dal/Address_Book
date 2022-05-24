using AddressBook;
internal class Program
{
    public static List<Contacts> person = new List<Contacts>();

    public static void Main(String[] args)
    {
        Console.WriteLine("1.Create Contact\n2.Edit Contact\n3.Delete Contact\n4.Display Contacts\n5.exit:\n");
        Console.WriteLine("Enter your choice:");
        int choice = Convert.ToInt32(Console.ReadLine());
        while (choice != 5)
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
                    AddressBook.Person.displayContacts();
                    break;
                default:
                    Console.Write("Enter valid option.\n");
                    break;

            }
            Console.WriteLine("1.Create Contact\n2.Edit Contact\n3.Delete Contact\n4.Display Contacts\n5.exit:\n");
            Console.WriteLine("Enter your choice:");
            choice = Convert.ToInt32(Console.ReadLine());

        }
    }
}