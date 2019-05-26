using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.Dto;
using WebAPI.Models.Orm;

namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        WEBAPITESTEntities db = new WEBAPITESTEntities();

        //List all students with only name,surname without department
        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> stdList = db.Student.Select(x => new StudentModel()
            {

                StudentName = x.Name,
                StudentSurname = x.Surname
            }).ToList();

            return stdList;
        }

        //Only find as a from model with id.
        public StudentModel GetStudentById(int id)
        {
            Student std = db.Student.Find(id);
            StudentModel stdModel = new StudentModel();
            stdModel.StudentName = std.Name;
            stdModel.StudentSurname = std.Surname;
            return stdModel;
        }

        //add new student to db with json format
        [HttpPost]
        public IHttpActionResult AddStudent(StudentModel _model)
        {
            Student std = new Student()
            {
                Name = _model.StudentName,
                Surname = _model.StudentSurname
            };
            db.Student.Add(std);
            db.SaveChanges();

            return Json("succ");
        }

        //also it will add auth. part and other actions
    }
}
