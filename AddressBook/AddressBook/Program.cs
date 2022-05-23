using AddressBook;
internal class Program
{
    public static List<Contacts> person = new List<Contacts>();

    public static void Main(String[] args)
    {

        AddressBook.Person.createContacts();
        AddressBook.Person.displayContacts();
        AddressBook.Person.editContacts();
        
    }
}