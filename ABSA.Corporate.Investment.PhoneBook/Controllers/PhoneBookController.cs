using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Managers;
using AutoMapper;


namespace ABSA.Corporate.Investment.PhoneBook.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly ILogger<PhoneBookController> _logger;

        private readonly IPhoneBookManager _phoneBookManager;

        private readonly IMapper _mapper;
        public PhoneBookController(ILogger<PhoneBookController> logger, IPhoneBookManager phoneBookManager, IMapper mapper)
        {
            _logger = logger;
            _phoneBookManager = phoneBookManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = nameof(GetPhoneBookById))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Models.PhoneBook))]
        public ActionResult<Models.PhoneBook> GetPhoneBookById(long id)
        {
            try
            {
                var domainPhoneBook = _phoneBookManager.GetPhoneBook(id);
                var phoneBook = _mapper.Map<Domain.Models.PhoneBook, Models.PhoneBook>(domainPhoneBook);
                return  Ok(phoneBook);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpGet("GetAll")]
        [SwaggerOperation(OperationId = nameof(GetAll))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.PhoneBook>))]
        public ActionResult<IEnumerable<Models.PhoneBook>> GetAll()
        {
            try
            {
                var domainPhoneBooks = _phoneBookManager.GetAll();
                var phoneBooks = _mapper.Map<IEnumerable<Domain.Models.PhoneBook>, IEnumerable<Models.PhoneBook>>(domainPhoneBooks);
                return Ok(phoneBooks);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost("CreateOrUpdatePhoneBook")]
        [SwaggerOperation(OperationId = nameof(CreateOrUpdatePhoneBook))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Models.PhoneBook))]
        public ActionResult<Domain.Models.PhoneBook> CreateOrUpdatePhoneBook(Models.PhoneBook phoneBook)
        {
            try
            {
                var domainPhoneBook = _mapper.Map<Models.PhoneBook,Domain.Models.PhoneBook>(phoneBook);
                _phoneBookManager.CreateOrUpdatePhoneBook(domainPhoneBook);
                var result = _mapper.Map<Domain.Models.PhoneBook, Models.PhoneBook>(domainPhoneBook);
                return Ok(domainPhoneBook);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = nameof(DeletePhoneBook))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Models.PhoneBook))]
        public ActionResult DeletePhoneBook(long id)
        {
            try
            {
                _phoneBookManager.DeletePhoneBook(id);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
