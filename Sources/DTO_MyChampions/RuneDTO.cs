using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_MyChampions
{
    public class RuneDTO
    {
        public string Name { get; set; }
        public RuneFamily RuneFamily { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
    }
}
