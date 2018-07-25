using ContactsManager.Core;
using ContactsManager.Data;
using System;
using System.Collections.Generic;

namespace ContactsManager.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactUnitOfWork _contactUnitOfWork;

        public ContactService(IContactUnitOfWork contactUnitOfWork)
        {
            _contactUnitOfWork = contactUnitOfWork;
        }

        public long AddContact(Contact contact)
        {
            _contactUnitOfWork.ContactRepository.Insert(contact);
            _contactUnitOfWork.Save();
            return contact.ContactId;
        }

        public void UpdateContact(Contact contact)
        {
            _contactUnitOfWork.ContactRepository.Update(contact);
            _contactUnitOfWork.Save();

        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactUnitOfWork.ContactRepository.Get();
        }

        public Contact GetContact(long contactId)
        {
            return _contactUnitOfWork.ContactRepository.GetById(contactId);
        }

        public void DeleteContact(long contactId)
        {
            _contactUnitOfWork.ContactRepository.Delete(contactId);
            _contactUnitOfWork.Save();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contactUnitOfWork.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
