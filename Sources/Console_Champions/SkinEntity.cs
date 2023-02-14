using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public class SkinEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public LargeImage? Image { get; set; }
        public float? Price { get; set; }
        public ChampionEntity Champion { get; set; }
        
        public SkinEntity(string name, ChampionEntity champion, float price = 0.0f, string icon = "", string image = "", string description = "")
        {
            Name = name;
            Champion = champion;
        }
    }

    
}
