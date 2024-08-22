using Contact_Manager_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Services.UserServices
{
    public partial class UserServices
    {
        private User user;
        public User User => this.user;

        public UserServices(User user)
        {
            user = new User();
            this.user = user;
        }

        public bool AddAddress(Address address)
        {
            if (!user.AddressList.Contains(address))
            {
                user.AddressList.Add(address);
                return true;
            }
            return false;
        }

        public bool AddPhone(Phone phone)
        {
            if (!user.PhoneList.Contains(phone))
            {
                user.PhoneList.Add(phone);
                return true;
            }
            return false;
        }

        public bool AddEmail(Email email)
        {
            if (!user.EmailList.Contains(email))
            {
                user.EmailList.Add(email);
                return true;
            }
            return false;
        }
    }
}
