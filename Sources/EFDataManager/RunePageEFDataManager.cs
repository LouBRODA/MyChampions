using Console_Champions.Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class RunePageEFDataManager extends IRunePagesManager redefining all methods of Manager

namespace EFDataManager
{
    public class RunePageEFDataManager : IRunePagesManager
    {
        private readonly GeneralEFDataManager dataManager;

        public RunePageEFDataManager(GeneralEFDataManager dataManager)
            => this.dataManager = dataManager;

        public async Task<RunePage?> AddItem(RunePage? item)
        {
            await dataManager.EFDataContext.RunePageEntity.AddAsync(item.ToEntity());
            return item;
        }

        public async Task<bool> DeleteItem(RunePage? item)
        {
            dataManager.EFDataContext.RunePageEntity.Remove(item.ToEntity());
            return true;
        }

        public Task<IEnumerable<RunePage?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RunePage?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RunePage?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RunePage?>> GetItemsByRune(Model.Rune? rune, int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNbItems()
        {
            return dataManager.EFDataContext.RunePageEntity.Count();
        }

        public Task<int> GetNbItemsByChampion(Champion? champion)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByName(string substring)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItemsByRune(Model.Rune? rune)
        {
            throw new NotImplementedException();
        }

        public async Task<RunePage?> UpdateItem(RunePage? oldItem, RunePage? newItem)
        {
            dataManager.EFDataContext.RunePageEntity.Remove(oldItem.ToEntity());
            dataManager.EFDataContext.RunePageEntity.Add(newItem.ToEntity());
            return newItem;
        }
    }
}
