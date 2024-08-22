using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models
{
    public class Phone : AdditionalData
    {
        private string phone;
        public string PhoneNumber { get => phone; set => phone = value; }
        public Phone()
        {
            phone = "+050";
        }

        public Phone(string phone, string type, string descripton)
            :base(type, descripton)
        {
            this.phone = phone;
        }

        public override string ToString()
        {
            return $"[Phone : {phone}, {base.ToString()}]";
        }
    }
}
