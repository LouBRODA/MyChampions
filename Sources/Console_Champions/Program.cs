// See https://aka.ms/new-console-template for more information
using Console_Champions;
using Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;

Console.WriteLine("Hello, World!");

using (var context = new ChampionContext())
{
    context.ChampionEntity.AddRange(
        new ChampionEntity
        {
            Name = "Akali",
            Class = (ChampClassEntity?)1,
            Icon = "iconAkali",
            Image = "imageAkali",
            Bio = "bioAkali",
},
        new ChampionEntity
        {
            Name = "Aatrox",
            Class = (ChampClassEntity?)2,
            Icon = "iconAatrox",
            Image = "imageAatrox",
            Bio = "bioAatrox",
        },
        new ChampionEntity
        {
            Name = "Ahri",
            Class = (ChampClassEntity?)3,
            Icon = "iconAhri",
            Image = "imageAhri",
            Bio = "bioAhri",
        }
    );
    context.SaveChanges();
}
