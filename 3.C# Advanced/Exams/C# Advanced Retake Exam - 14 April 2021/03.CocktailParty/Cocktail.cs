using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);
        public List<Ingredient> Ingredients { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Contains(ingredient) && Capacity >= Ingredients.Count + 1 && MaxAlcoholLevel >= ingredient.Alcohol)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);

            if (ingredient != null)
            {
                Ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}
