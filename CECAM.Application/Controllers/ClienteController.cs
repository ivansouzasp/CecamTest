using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CECAM.Domain.Dtos;
using CECAM.Domain.Interfaces.LogicLayer;
using CECAM.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CECAM.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController: ControllerBase
    {
        private readonly IClienteLogic _clienteLogic;
        private readonly IMapper _mapper;
        //private readonly ILogger<ClienteController> _logger;
        //Logger<ClienteController> logger;
        public ClienteController(IClienteLogic clienteLogic,
                                 IMapper mapper)
        {
            _clienteLogic = clienteLogic;
            _mapper = mapper;
            //_logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _clienteLogic.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _clienteLogic.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCliente")]
        public async Task<ActionResult> AddCliente([FromBody] ClienteDto cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var clienteEntity = _mapper.Map<Cliente>(cliente);
                var result = await _clienteLogic.Add(clienteEntity);
                if (result > 0)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCliente")]
        public async Task<ActionResult> Update([FromBody] ClienteDto cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var clienteEntity = _mapper.Map<Cliente>(cliente);
                var result = await _clienteLogic.Update(clienteEntity);
                if (result > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "RemoveCliente")]
        public async Task<ActionResult> Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _clienteLogic.Remove(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
