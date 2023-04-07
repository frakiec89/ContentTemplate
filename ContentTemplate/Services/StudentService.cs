using ContentTemplate.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentTemplate.Services
{
    internal class StudentService
    {

        public void AddStudent (Student student )
        {
            try
            {
                DB.MyContext context = new DB.MyContext();
                 context.Students.Add(student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Student> GetStudents ()
        {
            try
            {
                DB.MyContext context = new DB.MyContext();
                return context.Students.Include(x => x.Group).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }
    }
}
