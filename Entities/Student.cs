using System.Collections;
using System.Collections.Generic;
using UppgiftenSTSAPI.Entities;

namespace UppgiftenSTSAPI.Context
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public IList<StudentSeminar> studentseminars { get; set; }
        public int currentDormId { get; set; }
        public Dorm dorm { get; set; }
    }
}