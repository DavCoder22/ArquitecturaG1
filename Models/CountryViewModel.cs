using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArquitecturaG1.Models
{
    public class CountryViewModel
    {
        public string SelectedCountry { get; set; }
        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
    }
}