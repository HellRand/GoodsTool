using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsToolReworked
{
    public class Model
    {
        public Model(int id, string name = "", int count = 0)
        {
            Id = id;
            Name = name;
            Count = count;
            Products = new List<Product>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Наименование модели товара.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Общее количество товаров модели (характеристики не имеют значения)
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Общая цена товара модели (характеристики не имеют значения).
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Вариации этой модели с характеристиками
        /// </summary>
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $"[id={Id}] {Name}. Кол-во: {Count}.";// Цена: {Price}p.";
        }
    }
}