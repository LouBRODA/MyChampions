using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SkinDTO class with all attributes linked

namespace DTO_MyChampions
{
    public class SkinDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public float Price { get; set; }
    }
}
