using Model;
using DTO_MyChampions;

namespace API_MyChampions.Mapper
{
    public static class ChampionMapper
    {
        public static ChampionDTO toDTO(this Champion champion)
        {
            return new ChampionDTO()
            {
                Name = champion.Name,
            };
        }
    }
}