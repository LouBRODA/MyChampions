using Model;
using DTO_MyChampions;
using System.Xml.Linq;

namespace API_MyChampions.Mapper
{
    public static class ChampionMapper
    {
        public static ChampionDTO ToDTO(this Champion champion)
        {
            return new ChampionDTO()
            {
                Name = champion.Name,
                Icon = champion.Icon,
                Bio = champion.Bio,
            };
        }

        public static Champion ToModel(this ChampionDTO championDTO)
        {
            return new Champion(championDTO.Name);
        }
    }
}