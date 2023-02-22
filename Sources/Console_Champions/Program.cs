// See https://aka.ms/new-console-template for more information
using Console_Champions;
using Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using StubLib;
using Console_Champions.Mapper;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

    /*StubData stubData = new StubData();
    var champions = ( await stubData.ChampionsMgr.GetItems(0, 
                      (await stubData.ChampionsMgr.GetNbItems()))).Select(champion => champion?.ToEntity());*/

using (ChampionContext context = new ChampionContext())
{
    foreach (var c in context.ChampionEntity.Include(c => c.Skins))
    {
    }
    context.SaveChanges();
}
