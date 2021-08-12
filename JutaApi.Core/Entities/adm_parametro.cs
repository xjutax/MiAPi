using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JutaApi.Core.Entities
{
    public class adm_parametro
    {
        public int idparametro { get; set; }
        public string parametro { get; set; }
        public string valor { get; set; }
        public string tipo { get; set; }
        public string grupo { get; set; }
        public string descripcion { get; set; }
    }
}
