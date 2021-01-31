using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Managers;
using AutoMapper;


namespace ABSA.Corporate.Investment.PhoneBook.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;

        private readonly IEntryManager _entryManager;

        private readonly IMapper _mapper;
        public EntryController(ILogger<EntryController> logger, IEntryManager entryManager, IMapper mapper)
        {
            _logger = logger;
            _entryManager = entryManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = nameof(GetEntryById))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Models.Entry))]
        public ActionResult<Models.Entry> GetEntryById(long id)
        {
            try
            {
                var domainEntry = _entryManager.GetEntry(id);
                var entry = _mapper.Map<Domain.Models.Entry, Models.Entry>(domainEntry);
                return  Ok(entry);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost("CreateOrUpdateEntry")]
        [SwaggerOperation(OperationId = nameof(CreateOrUpdateEntry))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Models.Entry))]
        public ActionResult<Models.Entry> CreateOrUpdateEntry(Models.Entry entry)
        {
            try
            {
                var domainEntry = _mapper.Map<Models.Entry,Domain.Models.Entry>(entry);
                _entryManager.CreateOrUpdateEntry(domainEntry);
                var result = _mapper.Map<Domain.Models.Entry, Models.Entry>(domainEntry);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = nameof(DeleteEntry))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Models.Entry))]
        public ActionResult DeleteEntry(long id)
        {
            try
            {
                _entryManager.DeleteEntry(id);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
