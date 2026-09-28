using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;
namespace UniversityApp.Controllers;
public class HomeController : Controller
{
   University university=new()
   {
     Name="global science university",
     Address="galkacyo",
     Email="gsu@gmail.com",
     Phone=9048477  
   };
    public IActionResult Index()
    {
        return View(university);
    }
    
}