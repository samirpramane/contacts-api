using ContactsManager.Web.Application;
using ContactsManager.Web.Models;
using System;
using System.Net;
using System.Web.Http;

namespace ContactsManager.Web.Controllers
{
    public class ContactController : ApiController
    {
        #region "Properties"

        private readonly IContactAppService _contactAppService;

        #endregion

        #region "Constructor"

        public ContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }

        #endregion

        [HttpGet]
        public ApiHttpResponse GetContacts()
        {
            return new ApiHttpResponse { HttpStatusCode = HttpStatusCode.OK, Response = _contactAppService.GetAllContacts() };
        }

        [HttpGet]
        public ApiHttpResponse GetContact(long id)
        {
            ContactViewModel contactViewModel = _contactAppService.GetContact(id);
            if (contactViewModel == null)
            {
                return new ApiHttpResponse { HttpStatusCode = HttpStatusCode.NotFound };
            }

            return new ApiHttpResponse { HttpStatusCode = HttpStatusCode.OK, Response = contactViewModel };
        }

        [HttpPost]
        public ApiHttpResponse PostContact([FromBody]ContactViewModel contactViewModel)
        {
            ApiHttpResponse apiHttpResponse = new ApiHttpResponse();

            if (!ModelState.IsValid)
            {
                apiHttpResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                return apiHttpResponse;
            }

            try
            {
                ContactViewModel contactViewModelResponse = _contactAppService.AddContact(contactViewModel);
                if (contactViewModelResponse.ContactId != 0)
                {
                    apiHttpResponse.HttpStatusCode = HttpStatusCode.OK;
                    apiHttpResponse.Response = contactViewModelResponse;
                }
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }

            return apiHttpResponse;
        }

        [HttpPut]
        public ApiHttpResponse PutContact(long id, ContactViewModel contactViewModel)
        {
            ApiHttpResponse apiHttpResponse = new ApiHttpResponse();

            if (id != contactViewModel.ContactId)
            {
                apiHttpResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                return apiHttpResponse;
            }

            try
            {
                _contactAppService.UpdateContact(contactViewModel);
                apiHttpResponse.HttpStatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }

            return apiHttpResponse;
        }

        [HttpDelete]
        public ApiHttpResponse DeleteContact(long id)
        {
            ApiHttpResponse apiHttpResponse = new ApiHttpResponse();

            try
            {
                _contactAppService.DeleteContact(id);
                apiHttpResponse.HttpStatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }

            return apiHttpResponse;
        }

        private ApiHttpResponse CreateErrorResponse(Exception exception)
        {
            return new ApiHttpResponse { HttpStatusCode = HttpStatusCode.InternalServerError, Response = exception };
        }
    }
}
