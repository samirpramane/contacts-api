using ContactsManager.Core;
using System;
using System.Collections.Generic;

namespace ContactsManager.Services
{
    public interface IContactService : IDisposable
    {
        long AddContact(Contact contact);
        void UpdateContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact GetContact(long contactId);
        void DeleteContact(long contactId);
    }
}
