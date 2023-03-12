using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions.Mapper
{
    public static class SkillMapper
    {
        public static SkillEntity ToEntity(this Skill skill)
        {
            return new SkillEntity
            {
                Name = skill.Name,
                Description = skill.Description,
                Type = (SkillTypeEntity?)skill.Type,
            };
        }
    }
}
