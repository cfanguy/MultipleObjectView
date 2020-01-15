using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLTableViews.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SQLTableViews.Controllers
{
    public class ClassroomController : Controller
    {
        // GET: /ClassRoom/Details/id
        public IActionResult Details(int? id)
        {
            dynamic myModel = new ExpandoObject();

            var classNameList = GetClassLUTList().Where(x => x.ClassID == id).ToList();
            myModel.classNameList = classNameList;

            var classInfo = GetClassList().Where(x => x.ClassID == id).ToList();

            var studentList = new List<Student>();
            foreach(var cl in classInfo)
            {
                var student = GetStudentList().FirstOrDefault(x => x.StudentID == cl.StudentID);
                studentList.Add(student);
            }
            myModel.studentList = studentList;

            return View(myModel);
        }


        [NonAction]
        public List<Student> GetStudentList()
        {
            return new List<Student>{
              new Student{
                 StudentID = 1,
                 Name = "Allan"
              },

              new Student{
                 StudentID = 2,
                 Name = "Bobby"
              },

              new Student{
                 StudentID = 3,
                 Name = "Carson"
              },
           };
        }

        [NonAction]
        public List<Class> GetClassList()
        {
            return new List<Class>{
              new Class{
                 ClassID = 1,
                 StudentID = 1
              },
              new Class{
                 ClassID = 1,
                 StudentID = 2
              },

              new Class{
                 ClassID = 2,
                 StudentID = 1
              },
              new Class{
                 ClassID = 2,
                 StudentID = 3
              },
           };
        }

        [NonAction]
        public List<ClassLUT> GetClassLUTList()
        {
            return new List<ClassLUT>
            {
                new ClassLUT
                {
                    ClassID = 1,
                    Name = "Math"
                },
                new ClassLUT
                {
                    ClassID = 2,
                    Name = "Science"
                },
            };
        }

    }
}
