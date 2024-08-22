using Contact_Manager_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Services.UserServices
{
    public partial class UserServices
    {
        public bool DeleteAddress(string _address)
        {
            if (user.AddressList.Any(a => a.AddressName == _address))
            {
                user.AddressList.RemoveAll(a => a.AddressName == _address);
                return true;
            }
            return false;
        }

        public bool DeletePhone(string _phone)
        {
            if (user.PhoneList.Any(a => a.PhoneNumber == _phone))
            {
                user.PhoneList.RemoveAll(a => a.PhoneNumber == _phone);
                return true;
            }
            return false;
        }

        public bool DeleteEmail(string _email)
        {
            if (user.EmailList.Any(a => a.EmailAddress == _email))
            {
                user.EmailList.RemoveAll(a => a.EmailAddress == _email);
                return true;
            }
            return false;
        }
    }
}
