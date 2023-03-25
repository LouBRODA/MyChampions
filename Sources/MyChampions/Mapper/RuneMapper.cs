using DTO_MyChampions;
using Model;

//Mapper used to switch between Rune types (DTO & Model)

namespace API_MyChampions.Mapper
{
    public static class RuneMapper
    {
        public static RuneDTO ToDTO(this Rune rune)
        {
            return new RuneDTO()
            {
                Name = rune.Name,
                RuneFamily = rune.Family,
                Icon = rune.Icon,
                Image = rune.Image.Base64,
                Description = rune.Description,
            };
        }

        public static Rune ToModel(this RuneDTO runeDTO)
        {
            return new Rune(runeDTO.Name, runeDTO.RuneFamily, runeDTO.Icon,runeDTO.Image, runeDTO.Description);
        }
    }
}
