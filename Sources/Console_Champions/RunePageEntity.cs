using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//RunePageEntity class with all attributes placed in the table

namespace Console_Champions
{
    public class RunePageEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<RuneEntity>? Runes { get; set; }
        public ICollection<ChampionEntity>? Champions { get; set; }

    }
}
