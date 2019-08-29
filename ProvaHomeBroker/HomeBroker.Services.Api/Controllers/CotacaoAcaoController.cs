using HomeBroker.Application.Interfaces;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace HomeBroker.Services.Api.Controllers
{

    public class CotacaoAcaoController : ApiController
    {
        #region Propriedades
        private readonly ICotacaoAcaoAppService _cotacaoAcaoAppService;
        #endregion

        #region Construtores
        public CotacaoAcaoController(ICotacaoAcaoAppService cotacaoAcaoAppService, NotificationContext notifications) : base(notifications)
        {
            _cotacaoAcaoAppService = cotacaoAcaoAppService;
        }
        #endregion

        #region Actions que consultam cotacoes
        [HttpGet]
        [Route("cotacao")]
        public IActionResult GetAll() => 
            Response(_cotacaoAcaoAppService.GetAll());

        [HttpGet]
        [Route("cotacao/{id:int}")]
        public IActionResult Get(int id) =>
           Response(_cotacaoAcaoAppService.GetById(id));
        #endregion

        #region Actions que alteram o estado de uma cotacao
        [HttpPost]
        [Route("cotacao")]
        public IActionResult Post([FromBody] CotacaoAcaoViewModel cotacao)
        {
            _cotacaoAcaoAppService.Add(cotacao);
            return Response(cotacao);
        }

        [HttpPut]
        [Route("cotacao")]
        public IActionResult Put([FromBody] CotacaoAcaoViewModel cotacao)
        {
            _cotacaoAcaoAppService.Update(cotacao);
            return Response();
        }

        [HttpDelete]
        [Route("cotacao/{id:int}")]
        public IActionResult Delete(int id)
        {
            _cotacaoAcaoAppService.Remove(id);
            return Response();
        }
        #endregion
    }
}
