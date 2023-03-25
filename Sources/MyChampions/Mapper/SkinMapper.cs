using DTO_MyChampions;
using Model;

//Mapper used to switch between Skin types (DTO & Model)

namespace API_MyChampions.Mapper
{
    public static class SkinMapper
    {
        public static SkinDTO ToDTO(this Skin skin)
        {
            return new SkinDTO()
            {
                Name = skin.Name,
                Description= skin.Description,
                Icon = skin.Icon,
                Price = skin.Price,
            };
        }

        public static Skin ToModel(this SkinDTO skinDTO)
        {
            return new Skin(skinDTO.Name, null, skinDTO.Price, skinDTO.Icon, skinDTO.Description);
        }
    }
}
