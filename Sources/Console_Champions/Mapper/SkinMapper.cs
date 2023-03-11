using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions.Mapper
{
    public static class SkinMapper
    {
        public static SkinEntity ToEntity(this Skin skin)
        {
            return new SkinEntity
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Image = skin.Image.Base64,
                Price = skin.Price,
                Champion = skin.Champion.ToEntity(),
            };
        }
    }
}
