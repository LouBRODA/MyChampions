using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions.Mapper
{
    public static class RunePageMapper
    {
        public static RunePageEntity ToEntity(this RunePage runePage)
        {
            return new RunePageEntity
            {
                Name = runePage.Name,

            };
        }
    }
}
