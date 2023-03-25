using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SkillEntity class with all attributes placed in the table

namespace Console_Champions
{
    public class SkillEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SkillTypeEntity? Type { get; set; }
        public ICollection<ChampionEntity>? Champions { get; set; }
    }
}
