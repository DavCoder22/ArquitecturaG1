using System;

namespace ArquitecturaG1.Models.DTO
{
    public class PaisesDto
    {
        //Declarando los atributos
        private string _name;
        private string _continent;
        private string _region;
        private int _population;
        private string _localname;
        private int _capital;

        //Get y Set de los atributos
        public string Name { get => _name; set => _name = value; }
        public string Continent { get => _continent; set => _continent = value; }
        public string Region { get => _region; set => _region = value; }
        public int Population { get => _population; set => _population = value; }
        public string Localname { get => _localname; set => _localname = value; }
        public int Capital { get => _capital; set => _capital = value; }
    }
}