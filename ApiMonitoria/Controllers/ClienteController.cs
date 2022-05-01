using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiMonitoria.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMonitoria.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController : ControllerBase
    {
        private ApplicationContext context;

        [HttpGet]
        public List<Cliente> ListarClientes()
        {
            context = new ApplicationContext();
            List<Cliente> clientes = context.Clientes.ToList();

            return clientes;
        }

        [HttpGet]
        [Route("{id}")]
        public Cliente ListarClientePorId(int id)
        {
            context = new ApplicationContext();
            Cliente cliente = context.Clientes.Find(id);

            return cliente;
        }

        [HttpPost]
        [Route("Inserir")]
        public IActionResult InserirCliente([FromBody] Cliente cliente)
        {
            if(cliente == null)
            {
                return BadRequest();
            }

            context = new ApplicationContext();
            context.Add(cliente);
            context.SaveChanges();

            return RedirectToAction("ListarClientes");
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            context = new ApplicationContext();
            Cliente cliente = context.Clientes.Find(id);

            if(cliente == null)
            {
                return BadRequest();
            }

            context.Remove(cliente);
            context.SaveChanges();

            return Ok(cliente);

        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            context = new ApplicationContext();

            if(id != cliente.Id)
            {
                return BadRequest();
            }

            context.Update(cliente);
            context.SaveChanges();

            return Ok(cliente);
        }


    }
}
