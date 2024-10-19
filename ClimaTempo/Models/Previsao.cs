using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Models
{
    public class Previsao
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime Atualizado_em{ get; set; }
        public List<Clima> clima { get; set; }
    }
}
