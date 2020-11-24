using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsToolReworked
{
    public class Product
    {
        public Product(string size, string color, int count, int price)
        {
            Size = size;
            Color = color;
            Count = count;
            Price = price;
        }

        /// <summary>
        /// Размер
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Количество товара с текущими параметрами.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Стоимость товара с указанными параметрами.
        /// </summary>
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Size}, {Color}. Кол-во: {Count}. Цена: {Price}p.";
        }
    }
}