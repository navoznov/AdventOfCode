using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    internal class Cookie
    {
        protected readonly Dictionary<Ingredient, int> _composition;

        public int TeaspoonsCount
        {
            get { return _composition.Sum(x => x.Value); }
        }

        public Cookie()
        {
            _composition = new Dictionary<Ingredient, int>();
        }

        public void AddIngredientDose(Ingredient ingredient, int teaspoonsCount)
        {
            _composition.Add(ingredient, teaspoonsCount);
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            _composition.Remove(ingredient);
        }

        public virtual int GetScore()
        {
            var totalCapacity = 0;
            var totalDurability = 0;
            var totalFlavor = 0;
            var totalTexture = 0;
            var totalCalories = 0;
            foreach (var ingredientDose in _composition)
            {
                totalCapacity += ingredientDose.Key.Capacity*ingredientDose.Value;
                totalDurability += ingredientDose.Key.Durability*ingredientDose.Value;
                totalFlavor += ingredientDose.Key.Flavor*ingredientDose.Value;
                totalTexture += ingredientDose.Key.Texture*ingredientDose.Value;
                totalCalories += ingredientDose.Key.Calories*ingredientDose.Value;
            }
            return Math.Max(totalCapacity, 0)
                   *Math.Max(totalDurability, 0)
                   *Math.Max(totalFlavor, 0)
                   *Math.Max(totalTexture, 0)
                ;
        }
    }
}