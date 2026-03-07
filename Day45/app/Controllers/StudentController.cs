using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Repositories;

namespace app.Controllers;
public class StudentController : Controller
 {
     private readonly IStudentRepository repo;

     public StudentController(IStudentRepository repository)
     {
         repo = repository;
     }

     [HttpGet("students/all")]
     public IActionResult List()
     {
         var students = repo.GetAllStudents();

         List<string> result = new List<string>();

         foreach (var s in students)
         {
             int total = s.M1 + s.M2;
             result.Add($"{s.Name} Total = {s.M1 + s.M2}");
         }

         return Content(string.Join("\n", result));
     }

     public IActionResult Add()
     {
         Student s = new Student
         {
             Id = 3,
             Name = "Kumar",
             M1 = 75,
             M2 = 80
         };

         repo.AddStudent(s);

         return Content("Student Added");
     }
 }