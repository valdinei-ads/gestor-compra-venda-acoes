using HomeBroker.Application.Interfaces;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace HomeBroker.Services.Api.Controllers
{
    public class OrdemController : ApiController
    {
        #region Propriedades
        private readonly IOrdemAppService _ordemAppService;
        #endregion

        #region construtores
        public OrdemController(IOrdemAppService ordemAppService, NotificationContext notifications) : base(notifications)
        {
            _ordemAppService = ordemAppService;
        }
        #endregion

        #region Actions que consultam ordens
        [HttpGet]
        [Route("ordem")]
        public IActionResult Get() =>
            Response(_ordemAppService.GetAll());

        [HttpGet]
        [Route("ordem/{id:int}")]
        public IActionResult Get(int id) =>
            Response(_ordemAppService.GetById(id));
        #endregion

        #region Actions que alteram o estado de uma ordem
        [HttpPost]
        [Route("ordem")]
        public IActionResult Post([FromBody]  OrdemViewModel ordem)
        {
            _ordemAppService.Add(ordem);
            return Response(ordem);
        }
        #endregion
    }
}
