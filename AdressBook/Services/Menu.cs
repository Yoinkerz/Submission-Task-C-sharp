using AdressBook.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace AdressBook.Services;

public class Menu
{
    public List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Välkommen till Adressboken");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        Console.Write("Välj ett av alternativen ovan: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": CreateContact(); break;
            case "2": ShowAllContacts(); break;
            case "3": ShowSpecificContact(); break;
            case "4": DeleteContact(); break;
        }
    }
    public void CreateContact()
    {
        Console.Clear();
        Console.WriteLine("Skapa en ny kontakt.");

        Contact contact = new Contact();
        Console.Write("Ange Förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Ange Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Ange Adress: ");
        contact.Address = Console.ReadLine() ?? "";
        Console.Write("Ange Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Ange E-postadress: ");
        contact.Email = Console.ReadLine() ?? "";
        
        contacts.Add(contact);

        file.Save(FilePath, JsonConvert.SerializeObject(new { ContactList = contacts }));
    }

    private void ShowAllContacts()
    {
        Console.Clear();
        Console.WriteLine("Visar alla kontakter.");

        contacts.ForEach(contact => Console.WriteLine("\n" + "Förnamn: " + contact.FirstName + "\n" + "Efternamn: " + contact.LastName + "\n" + "E-postadress: " + contact.Email + "\n"));

        Console.ReadKey();

    }

    private void ShowSpecificContact()
    {
        Console.Clear();
        Console.WriteLine("Välj en kontakts E-postadress");

        contacts.ForEach(contact => Console.WriteLine("\n" + "Förnamn: " + contact.FirstName + "\n" + "Efternamn: " + contact.LastName + "\n" + "E-postadress: " + contact.Email + "\n"));

        string userInput = Console.ReadLine() ?? "";

        Console.Clear();

        foreach (var c in contacts)
        {
            if (userInput.Equals(c.Email))
                Console.WriteLine("\n" + "Förnamn: " + c.FirstName + "\n" + "Efternamn: " + c.LastName + "\n" + "E-postadress: " + c.Email + "\n" + "Telefonnummer: " + c.PhoneNumber + "\n" + "Adress: " + c.Address);
        }
        Console.ReadKey();
    }

    private void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("Välj en kontakt att ta bort genom att skriva E-postadressen");

        contacts.ForEach(contact => Console.WriteLine("\n" + "Förnamn: " + contact.FirstName + "\n" + "Efternamn: " + contact.LastName + "\n" + "E-postadress: " + contact.Email + "\n"));

        string userInput = Console.ReadLine() ?? "";

        for (int i = 0; i < contacts.Count; i++)
        {
           
            bool confirmed = false;

            while(!confirmed)
            {
                Console.WriteLine("\n" + "Är du säker på att du vill ta bort kontakten? y/n");
                string option = Console.ReadLine() ?? "";

                if(option == "y")
                {
                    Contact? c = contacts[i];
                    if (userInput.Equals(c.Email))
                        contacts.Remove(c);
                        confirmed = true;
                    Console.Clear();

                }
            }
            file.Save(FilePath, JsonConvert.SerializeObject(new { ContactList = contacts }));
        }   
    }
}
