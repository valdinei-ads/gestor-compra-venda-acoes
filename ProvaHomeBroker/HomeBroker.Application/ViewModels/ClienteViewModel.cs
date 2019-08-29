using HomeBroker.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HomeBroker.Application.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public TipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
    }
}
