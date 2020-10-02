using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UppgiftenSTSAPI.Entities;

namespace UppgiftenSTSAPI.Context
{
    public class Seminar
    {
        public int id { get; set; }
        public string seminarname { get; set; }

        public int SeminarOfPaymentmethodId { get; set; }
        public virtual Paymentmethod Paymentmethod { get; set; }
        public IList<StudentSeminar> studentSeminars { get; set; }
    
    }
}