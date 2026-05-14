
using System;
using System.ComponentModel;
using System.Data.Common;

namespace Laboratorio05.Ejercicio2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Entry { get; set; }
        public int Amount { get; set; }
    }
}
