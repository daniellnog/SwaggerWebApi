using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWebAPI.Models
{
    public interface IParametroValorRepositorio
    {
        IEnumerable<ParametroValor> GetAll();
        ParametroValor Get(int Id);
    }
}
