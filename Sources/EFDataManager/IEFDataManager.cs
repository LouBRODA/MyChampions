using Console_Champions;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataManager
{
    public class IEFDataManager : IDataManager
    {
        IChampionEFDataManager ChampionsMgr { get; }
        IChampionsManager IDataManager.ChampionsMgr => throw new NotImplementedException();
        public ISkinsManager SkinsMgr => throw new NotImplementedException();
        public IRunesManager RunesMgr => throw new NotImplementedException();
        public IRunePagesManager RunePagesMgr => throw new NotImplementedException();

        public IEFDataManager(ChampionContext context) => EFDataContext = context;
        public ChampionContext EFDataContext { get; }
            
    }

}
