using System;

namespace SimpleContactManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();
            string option;

            do
            {
                Console.WriteLine("\nSimple Contact Manager");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddContact(contactManager);
                        break;
                    case "2":
                        ViewContacts(contactManager);
                        break;
                    case "3":
                        UpdateContact(contactManager);
                        break;
                    case "4":
                        DeleteContact(contactManager);
                        break;
                    case "5":
                        contactManager.SaveContacts();
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (option != "5");
        }

        private static void AddContact(ContactManager contactManager)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Contact newContact = new Contact { Name = name, Email = email, Phone = phone };
            contactManager.AddContact(newContact);
            Console.WriteLine("Contact added successfully!");
        }

        private static void ViewContacts(ContactManager contactManager)
        {
            Console.WriteLine("\nContacts:");
            foreach (var contact in contactManager.GetContacts())
            {
                Console.WriteLine(contact);
            }
        }

        private static void UpdateContact(ContactManager contactManager)
        {
            Console.Write("Enter Contact ID to Update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter New Phone: ");
                string phone = Console.ReadLine();

                Contact updatedContact = new Contact { Name = name, Email = email, Phone = phone };
                contactManager.UpdateContact(id, updatedContact);
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a numerical value.");
            }
        }

        private static void DeleteContact(ContactManager contactManager)
        {
            Console.Write("Enter Contact ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                contactManager.DeleteContact(id);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a numerical value.");
            }
        }
    }
}
