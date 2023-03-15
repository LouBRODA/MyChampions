using Console_Champions;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StubLib.StubData;

namespace EFDataManager
{
    public class IEFDataManager : IDataManager
    {

        public IEFDataManager(ChampionContext context) => EFDataContext = context;

        public ChampionContext EFDataContext { get; }

        public IChampionsManager ChampionsMgr { get; }

        public ISkinsManager SkinsMgr { get; }

        public IRunesManager RunesMgr { get; }

        public IRunePagesManager RunePagesMgr { get; }
    }

}
