using Microsoft.AspNetCore.Mvc;
using TipCalculator.Models;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.tip15Percent = "";  
        ViewBag.tip20Percent = "";
        ViewBag.tip25Percent = "";
        return View();
    }

    [HttpPost]
    public IActionResult Index(TipCalculatorModel model)
    {
        if (ModelState.IsValid)
        {
            // create culture variable
                var culture = System.Globalization.CultureInfo
                    .CreateSpecificCulture("en-US");

            var result = model.CalculateTipPercents(model.CostOfMeal);
            ViewBag.tip15Percent = result[0] > 0 ? result[0].ToString("c2",culture) : "";  
            ViewBag.tip20Percent = result[1] > 0 ? result[1].ToString("c2",culture) : "";
            ViewBag.tip25Percent = result[2] > 0 ? result[2].ToString("c2",culture) : "";
        }
        else
        {
            ViewBag.tip15Percent = "";  
            ViewBag.tip20Percent = "";
            ViewBag.tip25Percent = "";
        }
        return View(model);
    }
}
