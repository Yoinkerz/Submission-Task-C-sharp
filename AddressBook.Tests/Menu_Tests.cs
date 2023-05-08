using AdressBook.Models;
using AdressBook.Services;

namespace AddressBook.Tests
{
    [TestClass]
    public class AddressBook_Tests
    {
        [TestMethod]
        public void Should_Add_Contact_To_List()
        {
            Menu menu = new Menu();
            Contact contact = new Contact();


            menu.contacts.Add(contact);

            Assert.AreEqual(1, menu.contacts.Count);
        }
    }
}