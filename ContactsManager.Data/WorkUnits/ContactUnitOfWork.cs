using ContactsManager.Core;
using System;

namespace ContactsManager.Data
{
    public class ContactUnitOfWork : IContactUnitOfWork, IDisposable
    {
        private readonly ContactDbContext _contactDbContext;

        private IGenericRepository<Contact> _contactRepository;

        public ContactUnitOfWork(ContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        public IGenericRepository<Contact> ContactRepository
        {
            get
            {
                if (this._contactRepository == null)
                {
                    this._contactRepository = new ContactRepository<Contact>(_contactDbContext);
                }
                return _contactRepository;
            }
        }

        public void Save()
        {
            _contactDbContext.SaveChanges();
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _contactDbContext.Dispose();
                }
            }
            this._disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
