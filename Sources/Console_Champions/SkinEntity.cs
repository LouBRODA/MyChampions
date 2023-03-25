using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SkinEntity class with all attributes placed in the table

namespace Console_Champions
{
    public class SkinEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? Image { get; set; }
        public float? Price { get; set; }
        public ChampionEntity? Champion { get; set; }
        
    }

    
}
