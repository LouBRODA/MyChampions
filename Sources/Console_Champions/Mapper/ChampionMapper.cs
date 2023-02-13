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
        private static string name;
        private static string icon;
        private static string image;
        private static string bio;

        public static ChampionEntity ToEntity(this Champion champion)
        {
            return new ChampionEntity(name, icon, image, bio)
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
