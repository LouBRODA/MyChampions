using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public class ChampionEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public ChampClassEntity? Class { get; set; }
        public string? Icon { get; set; }
        public string? Image { get; set; }
        public string? Bio { get; set; }

        public ICollection<Skin> Skins { get; set; }

        public ChampionEntity(string name, string icon, string image, string bio)
        {
            this.Name = name;
            this.Icon = icon;
            this.Image = image;
            this.Bio = bio;
        }
    }   
    
}
