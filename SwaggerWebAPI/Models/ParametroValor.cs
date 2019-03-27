using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwaggerWebAPI.Models
{
    public class ParametroValor
    {
        public int Id { get; set; }
        public int IdTestData { get; set; }
        public int IdParametro { get; set; }
        public string Valor { get; set; }
        public string DescricaoParametro { get; set; }
    }
}