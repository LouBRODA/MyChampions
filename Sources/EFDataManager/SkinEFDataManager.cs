using Console_Champions.Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataManager
{
    public class SkinEFDataManager : ISkinsManager
    {
        private readonly GeneralEFDataManager dataManager;

        public SkinEFDataManager(GeneralEFDataManager dataManager)
            => this.dataManager = dataManager;

        public async Task<Skin?> AddItem(Skin? item)
        {
            await dataManager.EFDataContext.SkinEntity.AddAsync(item.ToEntity());
            return item;
        }

        public async Task<bool> DeleteItem(Skin? item)
        {
            dataManager.EFDataContext.SkinEntity.Remove(item.ToEntity());
            return true;
        }

        public Task<IEnumerable<Skin?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skin?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNbItems()
        {
            return dataManager.EFDataContext.SkinEntity.Count();
        }

        public Task<int> GetNbItemsByChampion(Champion? champion)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByName(string substring)
        {
            throw new NotImplementedException();
        }

        public async Task<Skin?> UpdateItem(Skin? oldItem, Skin? newItem)
        {
            dataManager.EFDataContext.SkinEntity.Remove(oldItem.ToEntity());
            dataManager.EFDataContext.SkinEntity.Add(newItem.ToEntity());
            return newItem;
        }
    }
}
