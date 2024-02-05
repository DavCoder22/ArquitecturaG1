using ArquitecturaG1.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArquitecturaG1.Models.DTO
{
    public class IdiomasDto : IIdiomasDto
    {
        //Atributos de la base idiomas
        private string _CountryCode;
        private string _Languaje;
        private string _IsOfficial;
        private decimal _Percentage;

        //Propiedades getters and setter - países
        public string CountryCode { get => _CountryCode; set => _CountryCode = value; }
        public string Languaje { get => _Languaje; set => _Languaje = value; }
        public string IsOfficial { get => _IsOfficial; set => _IsOfficial = value; }
        public decimal Percentage { get => _Percentage; set => _Percentage = value; }

    }

    
}
