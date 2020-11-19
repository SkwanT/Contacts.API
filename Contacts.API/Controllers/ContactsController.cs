using AutoMapper;
using Contacts.API.DAL;
using Contacts.API.Entities;
using Contacts.API.Models;
using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Contacts.API.Controllers
{
    [RoutePrefix("api/contacts")]
    public class ContactsController : ApiController
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        private readonly IContactInteractor _interactor;

        public ContactsController(IContactRepository repository, IMapper mapper, IContactInteractor interactor)
        {
            _repository = repository;
            _mapper = mapper;
            _interactor = interactor;
        }

        [Route(Name = "GetContact")]
        public async Task<IHttpActionResult> Get(string searchValue = null)
        {
            try
            {
                var result = await _repository.GetAllContactsAsync(searchValue);

                var mappedResult = _mapper.Map<IEnumerable<ContactModel>>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var contact = await _repository.GetContactAsync(id);

                if (contact == null) return NotFound();

                var model = _mapper.Map<ContactModel>(contact);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("search/{searchValue}")]
        [HttpGet]
        public async Task<IHttpActionResult> SearchContacts(string searchValue)
        {
            try
            {
                var result = await _repository.GetAllContactsAsync(searchValue);

                var mappedResult = _mapper.Map<IEnumerable<ContactModel>>(result);

                return Ok(mappedResult);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route()]
        public async Task<IHttpActionResult> Post(ContactModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = _mapper.Map<Contact>(model);

                    if (!string.IsNullOrEmpty(model.TagName))
                    {
                        var tagname = await _repository.GetTagName(model.TagName);

                        contact.TagName = tagname;
                        contact.TagNameID = tagname.ID;
                    }

                    contact.PhoneNumbers = new List<PhoneNumber>();
                    contact.Emails = new List<Email>();

                    contact.PhoneNumbers = _interactor.PrepareList(contact.PhoneNumbers, model);
                    contact.Emails = _interactor.PrepareList(contact.Emails, model);

                    _repository.AddContact(contact);

                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<ContactModel>(contact);

                        return CreatedAtRoute("GetContact", new { contact = newModel.ID }, newModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, ContactModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = await _repository.GetContactAsync(id);
                    if (contact == null) return NotFound();

                    _mapper.Map(model, contact);

                    contact.PhoneNumbers = _interactor.PrepareList(contact.PhoneNumbers, model);
                    contact.Emails = _interactor.PrepareList(contact.Emails, model);

                    if (!string.IsNullOrEmpty(model.TagName))
                    {
                        var tagname = await _repository.GetTagName(model.TagName);

                        contact.TagName = tagname;
                        contact.TagNameID = tagname.ID;
                    }

                    if (await _repository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<ContactModel>(contact));
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest(ModelState);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var contact = await _repository.GetContactAsync(id);

                if (contact == null) return NotFound();

                _repository.DeleteContact(contact);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}