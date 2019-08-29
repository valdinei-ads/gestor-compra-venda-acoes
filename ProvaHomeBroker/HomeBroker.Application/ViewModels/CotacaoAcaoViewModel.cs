using System;

namespace HomeBroker.Application.ViewModels
{
    public class CotacaoAcaoViewModel
    {
        public int IdCotacaoAcao { get; set; }
        public string CodigoAcao { get; set; }
        public DateTime DataCotacao { get; set; }
        public decimal ValorCotacao { get; set; }
    }
}
