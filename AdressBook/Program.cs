
using AdressBook.Services;

var menu = new Menu();
menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";

while (true)
{
    Console.Clear();
    menu.MainMenu();
}