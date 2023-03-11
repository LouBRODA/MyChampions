using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions.Mapper
{
    public static class RuneMapper
    {
        public static RuneEntity ToEntity(this Model.Rune rune)
        {
            return new RuneEntity
            {
                Name = rune.Name,
                Description = rune.Description,
                Family = (RuneFamilyEntity?)rune.Family,
            };
        }
    }
}
