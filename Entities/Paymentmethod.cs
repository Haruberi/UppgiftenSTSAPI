namespace UppgiftenSTSAPI.Context
{
    public class Paymentmethod
    {
        public int id { get; set; }
        public string paymentmethodname { get; set; }
        public virtual Seminar seminar { get; set; }
    }
}