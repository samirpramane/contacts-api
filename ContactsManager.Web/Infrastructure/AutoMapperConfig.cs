using AutoMapper;
using ContactsManager.Core;
using ContactsManager.Web.Models;

namespace ContactsManager.Web.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region "ContactMapping"

            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();

            #endregion
        }
    }
}