// See https://aka.ms/new-console-template for more information
using Console_Champions;
using Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using StubLib;
using Console_Champions.Mapper;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Program.cs -> Console_Champions");

    /*
    StubData stubData = new StubData();
    var champions = ( await stubData.ChampionsMgr.GetItems(0, 
                      (await stubData.ChampionsMgr.GetNbItems()))).Select(champion => champion?.ToEntity());
    */

//Akali
using (ChampionContext context = new ChampionContext())
{

    ChampionEntity akali = new ChampionEntity { Id = 1, Name = "Akali", Class = ChampClassEntity.Assassin };

    SkinEntity[] akali_skin =
    {
        new SkinEntity { Id = 1, Champion = akali, Name = "Stinger" },
        new SkinEntity { Id = 2, Champion = akali, Name = "Infernal" },
        new SkinEntity { Id = 3, Champion = akali, Name = "All-Star" },
    };

    foreach (var s in akali_skin)
    {
        akali.Skins.Add(s);
    }

    SkillEntity[] akali_skill =
    {
        new SkillEntity { Id = 1, Name = "FirePower", Type = SkillTypeEntity.Basic },
    };

    foreach (var s in akali_skill)
    {
        akali.Skills.Add(s);
    }

    context.Add(akali);
    context.SaveChanges();
}

//Aatrox
using (ChampionContext context = new ChampionContext())
{

    ChampionEntity aatrox = new ChampionEntity { Id = 2, Name = "Aatrox", Class = ChampClassEntity.Fighter };

    SkinEntity[] aatrox_skin =
    {
        new SkinEntity { Id = 4, Champion = aatrox, Name = "Justicar" },
        new SkinEntity { Id = 5, Champion = aatrox, Name = "Mecha" },
        new SkinEntity { Id = 6, Champion = aatrox, Name = "Sea Hunter" },
    };

    foreach (var s in aatrox_skin)
    {
        aatrox.Skins.Add(s);
    }

    SkillEntity[] aatrox_skill =
    {
        new SkillEntity { Id = 2, Name = "MentalStrenght", Type = SkillTypeEntity.Passive },
    };

    foreach (var s in aatrox_skill)
    {
        aatrox.Skills.Add(s);
    }

    context.Add(aatrox);
    context.SaveChanges();
}

//Ahri
using (ChampionContext context = new ChampionContext())
{

    ChampionEntity ahri = new ChampionEntity { Id = 3, Name = "Ahri", Class = ChampClassEntity.Mage };

    SkinEntity[] ahri_skin =
    {
        new SkinEntity { Id = 7, Champion = ahri, Name = "Dynasty" },
        new SkinEntity { Id = 8, Champion = ahri, Name = "Midnight" },
        new SkinEntity { Id = 9, Champion = ahri, Name = "Foxfire" }
    };

    foreach (var s in ahri_skin)
    {
        ahri.Skins.Add(s);
    }

    SkillEntity[] ahri_skill =
    {
        new SkillEntity { Id = 3, Name = "UltimEnd", Type = SkillTypeEntity.Ultimate },
    };

    foreach (var s in ahri_skill)
    {
        ahri.Skills.Add(s);
    }

    context.Add(ahri);
    context.SaveChanges();
}

//Runes & RunePages
using (ChampionContext context = new ChampionContext())
{
    RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1" };
    RunePageEntity runePage2 = new RunePageEntity { Id = 2, Name = "RunePage2" };

    RuneEntity rune1 = new RuneEntity { Id = 1, Name = "Conqueror", Family = RuneFamilyEntity.Precision };
    RuneEntity rune2 = new RuneEntity { Id = 2, Name = "Triumph", Family = RuneFamilyEntity.Precision };
    RuneEntity rune3 = new RuneEntity { Id = 3, Name = "Legend: Alacrity", Family = RuneFamilyEntity.Precision };
    RuneEntity rune4 = new RuneEntity { Id = 4, Name = "Legend: Tenacity", Family = RuneFamilyEntity.Precision };
    RuneEntity rune5 = new RuneEntity { Id = 5, Name = "last stand", Family = RuneFamilyEntity.Domination };
    RuneEntity rune6 = new RuneEntity { Id = 6, Name = "last stand 2", Family = RuneFamilyEntity.Domination };

    runePage1.Runes.Add(rune1);
    runePage1.Runes.Add(rune2);
    runePage1.Runes.Add(rune3);

    runePage2.Runes.Add(rune4);
    runePage2.Runes.Add(rune5);
    runePage2.Runes.Add(rune6);

    context.AddRange(runePage1, runePage2);
    context.AddRange(rune1, rune2, rune3, rune4, rune5, rune6);
    context.SaveChanges();
}
