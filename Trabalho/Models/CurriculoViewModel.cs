using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class CurriculoViewModel
    {
        public int id { get; set; }
        public int cpf { get; set; }
        public string nome { get; set; }
        public int celular { get; set; }
        public string email { get; set; }
        public int cep { get; set; }
        public string rua { get; set; }
        public int numeroEnd { get; set; }
        public string bairro { get; set; }
        public string complementoEnd { get; set; }
        public string estado { get; set; }
        public string formacao { get; set; }
        public string curso1 { get; set; }
        public string curso2 { get; set; }
        public string curso3 { get; set; }
        public string curso4 { get; set; }
        public string curso5 { get; set; }
        public string experiencia1 { get; set; }
        public string experiencia1Desde { get; set; }
        public string experiencia1Ate { get; set; }
        public string experiencia2 { get; set; }
        public string experiencia2Desde { get; set; }
        public string experiencia2Ate { get; set; }
        public string experiencia3 { get; set; }
        public string experiencia3Desde { get; set; }
        public string experiencia3Ate { get; set; }
        public string cargoPretendido { get; set; }
    }
}
