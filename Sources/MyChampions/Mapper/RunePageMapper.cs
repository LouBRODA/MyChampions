using DTO_MyChampions;
using Model;

namespace API_MyChampions.Mapper
{
    public static class RunePageMapper
    {
        public static RunePageDTO ToDTO(this RunePage runePage)
        {
            return new RunePageDTO()
            {
                Name = runePage.Name,
            };
        }

        public static RunePage ToModel(this RunePageDTO runePageDTO)
        {
            return new RunePage(runePageDTO.Name);
        }
    }
}
