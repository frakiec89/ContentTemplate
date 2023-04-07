using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentTemplate.DB
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name; 
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string  PathImage { get; set; }
        public bool IsStudent { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }

}
