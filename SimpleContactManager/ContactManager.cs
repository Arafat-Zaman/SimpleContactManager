using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleContactManager
{
    public class ContactManager
    {
        private const string FilePath = "contacts.txt";
        private List<Contact> contacts;

        public ContactManager()
        {
            contacts = new List<Contact>();
            LoadContacts();
        }

        private void LoadContacts()
        {
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4 && int.TryParse(parts[0], out int id))
                    {
                        contacts.Add(new Contact { Id = id, Name = parts[1], Email = parts[2], Phone = parts[3] });
                    }
                }
            }
        }

        public void SaveContacts()
        {
            using (var writer = new StreamWriter(FilePath))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
        }

        public void AddContact(Contact contact)
        {
            contact.Id = contacts.Count + 1;
            contacts.Add(contact);
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                contact.Name = updatedContact.Name;
                contact.Email = updatedContact.Email;
                contact.Phone = updatedContact.Phone;
            }
        }

        public void DeleteContact(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }
    }
}
