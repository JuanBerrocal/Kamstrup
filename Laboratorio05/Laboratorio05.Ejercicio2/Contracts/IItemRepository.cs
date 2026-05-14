using Laboratorio05.Ejercicio2.Models;
using System.Collections.Generic;

namespace Laboratorio05.Ejercicio2.Contracts
{
    public interface IItemRepository
    {
        public List<Item> GetItems();
        public void CreateItem(Item item);
        public Item GetItemById(int id);
        public void UpdateItem(Item item);
        public void AddStock(int id, int amount);
        public void RemoveStock(int id, int amount);
    }
}
