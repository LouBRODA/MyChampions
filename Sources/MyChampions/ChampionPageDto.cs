using DTO_MyChampions;

//Class used to Pagination

namespace API_MyChampions
{
    public class ChampionPageDto
    {
        public IEnumerable<ChampionDTO> Data { get; set; }
        public int Index { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}
