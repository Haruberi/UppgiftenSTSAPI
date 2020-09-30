using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UppgiftenSTSAPI.Context;

namespace UppgiftenSTSAPI.Entities
{
    public class StudentSeminar
    {
        public int studentId { get; set; }
        public Student student { get; set; }
        public int seminarId { get; set; }
        public Seminar seminar { get; set; }
    }
}
