using AutoMapper;
using ContactsManager.Core;
using ContactsManager.Services;
using ContactsManager.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Web.Application
{
    public class ContactAppService : IContactAppService
    {
        private readonly IContactService _contactService;

        public ContactAppService(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ContactViewModel AddContact(ContactViewModel contactViewModel)
        {
            contactViewModel.ContactId = _contactService.AddContact(GetContact(contactViewModel));
            return contactViewModel;
        }

        public IEnumerable<ContactViewModel> GetAllContacts()
        {
            return Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(_contactService.GetAllContacts().Where(s => s.Status.Equals(false)));
        }

        public ContactViewModel GetContact(long contactId)
        {
            return Mapper.Map<Contact, ContactViewModel>(_contactService.GetContact(contactId));
        }

        public void UpdateContact(ContactViewModel contactViewModel)
        {
            Contact contact = _contactService.GetContact(contactViewModel.ContactId);
            _contactService.UpdateContact(GetContactTracked(contactViewModel, contact));
        }

        public void DeleteContact(long contactId)
        {
            Contact contact = _contactService.GetContact(contactId);
            if (contact != null)
            {
                contact.Status = true;
                _contactService.UpdateContact(contact);
            }
        }

        public Contact GetContact(ContactViewModel contactViewModel)
        {
            return Mapper.Map<ContactViewModel, Contact>(contactViewModel);
        }

        public Contact GetContactTracked(ContactViewModel contactViewModel, Contact contact)
        {
            contact.Email = contactViewModel.Email;
            contact.FirstName = contactViewModel.FirstName;
            contact.LastName = contactViewModel.LastName;
            contact.PhoneNumber = contactViewModel.PhoneNumber;
            contact.Status = contactViewModel.Status;
            return contact;
        }
    }
}