using HomeBroker.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HomeBroker.Application.ViewModels
{
    public class OrdemViewModel
    {
        public int IdOrdem { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public TipoOrdem TipoOrdem { get; set; }
        public DateTime DataOrdem { get; set; }
        public int IdCliente { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
        public string CodigoAcao { get; set; }
        public int QuantidadeAcoes { get; set; }
        public DateTime? DataCompra { get; set; }
        public decimal ValorOrdem { get; set; }
        public decimal TaxaCorretagem { get; set; }
        public decimal IR { get; set; }
    }
}
