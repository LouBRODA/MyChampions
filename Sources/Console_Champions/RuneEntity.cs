using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public  class RuneEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public RuneFamilyEntity? Family { get; set; }
        public ICollection<RunePageEntity>? RunePages { get; set; }

    }
}
