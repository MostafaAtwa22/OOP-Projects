using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models
{
    public abstract class AdditionalData
    {
        private string type;
        private string descripton;

        public AdditionalData()
        {
            type = descripton = "";
        }

        public AdditionalData(string type, string descripton)
        {
            this.type = type;
            this.descripton = descripton;
        }


        public string Type { get => type; set => type = value; }
        public string Descripton { get => descripton; set => descripton = value; }

        public override string ToString()
        {
            return $"Type : {type}, Description : {descripton}";
        }
    }
}
