namespace Day15
{
    internal class ExactCaloriesCookie : Cookie
    {
        private readonly int _caloriesCount;

        public ExactCaloriesCookie(int caloriesCount)
        {
            _caloriesCount = caloriesCount;
        }

        public override int GetScore()
        {
            var totalCalories = 0;
            foreach (var ingredientDose in _composition)
            {
                totalCalories += ingredientDose.Key.Calories*ingredientDose.Value;
            }
            return totalCalories == _caloriesCount ? base.GetScore() : 0;
        }
    }
}