using ContactsManager.Web.Models;
using System.Collections.Generic;


namespace ContactsManager.Web.Application
{
    public interface IContactAppService
    {
        ContactViewModel AddContact(ContactViewModel contactViewModel);
        void UpdateContact(ContactViewModel contactViewModel);
        IEnumerable<ContactViewModel> GetAllContacts();
        ContactViewModel GetContact (long contactId);
        void DeleteContact(long contactId);
    }
}
