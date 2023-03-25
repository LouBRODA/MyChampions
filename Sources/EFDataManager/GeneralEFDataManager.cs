using Console_Champions;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class to initialize all types of EFDataManager (Champions, Skins, Runes, RunePages)

namespace EFDataManager
{
    public class GeneralEFDataManager : IDataManager
    {

        public GeneralEFDataManager(ChampionContext context)
        {
            EFDataContext = context;
            ChampionsMgr = new ChampionEFDataManager(this);
            SkinsMgr = new SkinEFDataManager(this);
            RunesMgr = new RuneEFDataManager(this);
            RunePagesMgr = new RunePageEFDataManager(this);
        }

        public ChampionContext EFDataContext { get; }

        public IChampionsManager ChampionsMgr { get; }

        public ISkinsManager SkinsMgr { get; }

        public IRunesManager RunesMgr { get; }

        public IRunePagesManager RunePagesMgr { get; }
    }

}
