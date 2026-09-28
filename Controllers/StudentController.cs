
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;
namespace UniversityApp.Controllers;
public class StudentController : Controller
{
    private static readonly List<Student> Students = new()
    {
        new()
        {
            Id=1,
            Name="ali ahmed jama",
            Faculty="IT"
        },
        new()
        {
            Id=2,
            Name="hawa ahmed jama",
            Faculty="IT"
        },
        new()
        {
            Id=3,
            Name="muse ahmed jama",
            Faculty="BBA"
        },
         new()
        {
            Id=4,
            Name="halima aden jama",
            Faculty="medicine"
        }
    };

    private static readonly object StudentsLock = new();
    private static int _nextId = 5;

    public IActionResult Index()
    {
        lock (StudentsLock)
        {
            return View(Students.ToList());
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,Faculty")] Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        lock (StudentsLock)
        {
            student.Id = _nextId++;
            Students.Add(student);
        }

        return RedirectToAction(nameof(Index));
    }
}