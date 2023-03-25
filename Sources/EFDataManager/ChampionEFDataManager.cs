using Console_Champions.Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Class ChampionEFDataManager extends IChampionsManager redefining all methods of Manager

namespace EFDataManager
{
    public class ChampionEFDataManager : IChampionsManager
    {
        private readonly GeneralEFDataManager dataManager;

        public ChampionEFDataManager(GeneralEFDataManager dataManager)
            => this.dataManager = dataManager;

        public async Task<Champion?> AddItem(Champion? item)
        {
            await dataManager.EFDataContext.ChampionEntity.AddAsync(item.ToEntity());
            return item;
        }

        public async Task<bool> DeleteItem(Champion? item)
        {
            dataManager.EFDataContext.ChampionEntity.Remove(item.ToEntity());
            return true;
        }

        public Task<IEnumerable<Champion?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            return (Task<IEnumerable<Champion?>>)dataManager.EFDataContext.ChampionEntity.GetItemsWithFilterAndOrdering(
                c => true,
                index, count,
                orderingPropertyName, descending).Select(c => c.ToModel());
        }

        public Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsByRunePage(RunePage? runePage, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsBySkill(Skill? skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Champion?>> GetItemsBySkill(string skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNbItems()
        {
            return dataManager.EFDataContext.ChampionEntity.Count();
        }

        public async Task<int> GetNbItemsByCharacteristic(string charName)
        {
            throw new NotImplementedException();
            //return dataManager.EFDataContext.ChampionEntity.Where(c => c.Name.Equals(charName).Count();
        }

        public async Task<int> GetNbItemsByClass(ChampionClass championClass)
        {
            return dataManager.EFDataContext.ChampionEntity.Where(c => c.Class.Equals(championClass)).Count();
        }

        public async Task<int> GetNbItemsByName(string substring)
        {
            return dataManager.EFDataContext.ChampionEntity.Where(c => c.Name.Contains(substring)).Count();
        }

        public async Task<int> GetNbItemsByRunePage(RunePage? runePage)
        {
            return dataManager.EFDataContext.ChampionEntity.Where(c => c.RunePages.Any(r => r.Equals(runePage.ToEntity()))).Count();
        }

        public async Task<int> GetNbItemsBySkill(Skill? skill)
        {
            return dataManager.EFDataContext.ChampionEntity.Where(c => skill != null && c.Skills.Any(s => s.Name.Equals(skill.Name))).Count();
        }

        public async Task<int> GetNbItemsBySkill(string skill)
        {
            return dataManager.EFDataContext.ChampionEntity.Where(c => skill != null && c.Skills.Any(s => s.Name.Equals(skill))).Count();
        }

        public async Task<Champion?> UpdateItem(Champion? oldItem, Champion? newItem)
        {
            dataManager.EFDataContext.ChampionEntity.Remove(oldItem.ToEntity());
            dataManager.EFDataContext.ChampionEntity.Add(newItem.ToEntity());
            return newItem;
        }
    }
}
