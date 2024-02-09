using ArquitecturaG1.Models.DAO;
using System;

namespace ArquitecturaG1.Models.DTO
{
    public class PaisesDto : IPaisesDto
    {
        //Declarando los atributos
        private string _code;
        private string _name;
        private int _population;
       

        //Get y Set de los atributos

        public string Name { get => _name; set => _name = value; }
        public int Population { get => _population; set => _population = value; }
        public string Code { get => _code; set => _code = value; }
    }


}