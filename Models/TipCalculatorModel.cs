using System.ComponentModel.DataAnnotations;

namespace TipCalculator.Models
{
    public class TipCalculatorModel
    {
        [Required(ErrorMessage = "Please enter a Cost of Meal.")]
        [Range(1, 9999999, ErrorMessage =
               "Cost of Meal amount must be between 1 and 9999999.")]
        public decimal CostOfMeal { get; set; }

        public decimal[] CalculateTipPercents(decimal mealCost) =>
            new decimal[] { 
                percentValue(15,mealCost)
                ,percentValue(20,mealCost)
                ,percentValue(25,mealCost)
            };

        public decimal percentValue(int percent, decimal mealCost) => (mealCost/100) * percent; 
    }
}
