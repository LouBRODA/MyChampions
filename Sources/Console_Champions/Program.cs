// See https://aka.ms/new-console-template for more information
using Console_Champions;
using Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using StubLib;

Console.WriteLine("Hello, World!");

    StubData stubData = new StubData();
    var champions = stubData.ChampionsMgr.GetItems(0, await stubData.ChampionsMgr.GetNbItems());

using (var context = new ChampionContext())
{
    context.SaveChanges();
}
