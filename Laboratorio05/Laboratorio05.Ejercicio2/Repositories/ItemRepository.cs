using Laboratorio05.Ejercicio2.Contracts;
using Laboratorio05.Ejercicio2.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



namespace Laboratorio05.Ejercicio2.Repositories
{
    public class ItemRepository : IItemRepository
    {
        const string JSON_PATH = @"C:\Development\.net\kamstrup\Laboratorio05\Laboratorio05.Ejercicio2\Resources\Items.json";
        private string ReadItemsFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }

        private void UpdateItemsInFile(List<Item> items)
        {
            var json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(JSON_PATH, json);
        }
        public List<Item> GetItems()
        {
            try
            {
                var json = ReadItemsFromFile();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                return items;
            }
            catch
            {
                throw;
            }
        }
        public void CreateItem(Item item)
        {
            var items = GetItems();
            var itemExists = items.Exists(a => a.Id == item.Id);
            if (itemExists)
            {
                throw new Exception("Ese articulo ya existe.");
            }
            items.Add(item);
            UpdateItemsInFile(items);
        }

        public Item GetItemById(int id) 
        {
            try
            {
                List<Item> items = GetItems();
                var item = items.FirstOrDefault(a => a.Id == id);
                if (item == null) {
                    throw new Exception("Ese articulo no existe");
                }
                return item;
            }
            catch 
            {
                throw;
            }
        }

        public void UpdateItem(Item updatedItem) 
        {
            List<Item> items = GetItems();
            int index = items.FindIndex(a => a.Id == updatedItem.Id);
            if (index == -1) 
            {
                throw new Exception("Ese articulo no existe");
            }
            items[index] = updatedItem;

            UpdateItemsInFile(items); 
        }

        public void AddStock(int id, int amount) 
        {
            List<Item> items = GetItems();
            int index = items.FindIndex(a => a.Id == id);
            if (index == -1)
            {
                throw new Exception("Ese articulo no existe");
            }
            items[index].Amount += amount;

            UpdateItemsInFile(items);
        }

        public void RemoveStock(int id, int amount)
        {
            List<Item> items = GetItems();
            int index = items.FindIndex(a => a.Id == id);
            if (index == -1)
            {
                throw new Exception("Ese articulo no existe");
            }
            if ((items[index].Amount - amount) < 0)
            {
                throw new Exception("No hay stock suficiente");
            }
            items[index].Amount -= amount;

            UpdateItemsInFile(items);
        }
    }
}
