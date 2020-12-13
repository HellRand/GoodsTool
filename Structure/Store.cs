using System.Collections.Generic;

namespace GoodsToolReworked
{
    public class Store
    {
        public Store(int id, string name)
        {
            Id = id;
            Name = name;
            Models = new List<Model>();
        }

        /// <summary>
        /// Кол-во доступных моделей.
        /// </summary>
        public int AvailableModelsCount { get; set; }

        /// <summary>
        /// ID магазина.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Список моделей в текущем магазине.
        /// </summary>
        public List<Model> Models { get; set; }

        /// <summary>
        /// Имя магазина. (в нашем случае его адрес)
        /// </summary>
        public string Name { get; set; }

        public string GetFullInfo()
        {
            string result = $"Магазин: {this.ToString()} -----------------------------------------------------------------------\n";

            int ct = 1;
            for (int i = 0; i < Models.Count; i++)
            {
                if (Models[i].Count == 0) continue;
                result += $"{ct++}) " + Models[i].ToString() + "\n";
                foreach (Product p in Models[i].Products)
                {
                    result += $"\t{p.ToString()}\n";
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"[id={Id}] {Name}. Моделей в наличии: {AvailableModelsCount} (Всего: {Models.Count}).";
        }
    }
}