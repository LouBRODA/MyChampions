using Console_Champions.Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataManager
{
    public class IRuneEFDataManager : IRunesManager
    {
        private readonly IEFDataManager dataManager;

        public IRuneEFDataManager(IEFDataManager dataManager)
            => this.dataManager = dataManager;

        public async Task<Model.Rune?> AddItem(Model.Rune? item)
        {
            await dataManager.EFDataContext.RuneEntity.AddAsync(item.ToEntity());
            return item;
        }

        public async Task<bool> DeleteItem(Model.Rune? item)
        {
            dataManager.EFDataContext.RuneEntity.Remove(item.ToEntity());
            return true;
        }

        public Task<IEnumerable<Model.Rune?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.Rune?>> GetItemsByFamily(RuneFamily family, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.Rune?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNbItems()
        {
            return dataManager.EFDataContext.RuneEntity.Count();
        }

        public Task<int> GetNbItemsByFamily(RuneFamily family)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByName(string substring)
        {
            throw new NotImplementedException();
        }

        public async Task<Model.Rune?> UpdateItem(Model.Rune? oldItem, Model.Rune? newItem)
        {
            dataManager.EFDataContext.RuneEntity.Remove(oldItem.ToEntity());
            dataManager.EFDataContext.RuneEntity.Add(newItem.ToEntity());
            return newItem;
        }
    }
}
