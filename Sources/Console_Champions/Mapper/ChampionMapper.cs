using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions.Mapper
{
    public static class ChampionMapper
    {
        public static ChampionEntity ToEntity(this Champion champion)
        {
            return new ChampionEntity
            {
                Name = champion.Name,
                Class = (ChampClassEntity?)champion.Class,
                Bio = champion.Bio,
                Icon = champion.Icon,
                Image = champion.Image.Base64,
            };
        }
    }
}
