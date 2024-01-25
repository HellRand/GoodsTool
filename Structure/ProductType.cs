using System.Collections.Generic;

namespace GoodsToolReworked
{
    public class ProductType
    {
        public ProductType(int id, string name = "", int count = 0)
        {
            Id = id;
            Name = name;
            Count = count;
            Products = new List<Product>();
        }

        /// <summary>
        /// Общее количество товаров модели (характеристики не имеют значения)
        /// </summary>
        public int Count { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// Наименование модели товара.
        /// </summary>
        public string Name { get; set; }

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