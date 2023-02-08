// See https://aka.ms/new-console-template for more information
using Console_Champions;
using Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using StubLib;
using Console_Champions.Mapper;

Console.WriteLine("Hello, World!");

    StubData stubData = new StubData();
    var champions = ( await stubData.ChampionsMgr.GetItems(0, 
                      (await stubData.ChampionsMgr.GetNbItems()))).Select(champion => champion?.ToEntity());

using (var context = new ChampionContext())
{
    foreach (ChampionEntity champion in champions)
    {
        context.ChampionEntity.Add(champion);
    }
    context.SaveChanges();
}
