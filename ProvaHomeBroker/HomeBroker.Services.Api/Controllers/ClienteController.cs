using HomeBroker.Application.Interfaces;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace HomeBroker.Services.Api.Controllers
{
    public class ClienteController : ApiController
    {
        #region Propriedades
        private readonly IClienteAppService _clienteAppService;
        #endregion

        #region Construtores
        public ClienteController(IClienteAppService clienteAppService, NotificationContext notifications) : base(notifications)
        {
            _clienteAppService = clienteAppService;
        }
        #endregion

        #region Actions que consultam clientes
        [HttpGet]
        [Route("cliente")]
        public IActionResult Get() =>
            Response(_clienteAppService.GetAll());

        [HttpGet]
        [Route("cliente/{id:int}")]
        public IActionResult Get(int id) =>
            Response(_clienteAppService.GetById(id));
        #endregion

        #region Actions que alteram o estado de um cliente
        [HttpPost]
        [Route("cliente")]
        public IActionResult Post([FromBody] ClienteViewModel cliente)
        {
            _clienteAppService.Add(cliente);
            return Response(cliente);
        }

        [HttpPut]
        [Route("cliente")]
        public IActionResult Put([FromBody] ClienteViewModel cliente)
        {
            _clienteAppService.Update(cliente);
            return Response(cliente);
        }

        [HttpDelete]
        [Route("cliente/{id:int}")]
        public IActionResult Delete(int id)
        {
            _clienteAppService.Remove(id);
            return Response();
        }
        #endregion
    }
}
