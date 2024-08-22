using Contact_Manager_Application.Models;

namespace Contact_Manager_Application.Services.UserServices
{
    public partial class UserServices
    {
        public Address SearchAddres(string _address)
            => user.AddressList.FirstOrDefault(a => a.AddressName.ToLower() == _address.ToLower());
        public Email SearchEmail(string _email)
            => user.EmailList.FirstOrDefault(e => e.EmailAddress.ToLower() == _email.ToLower()); 
        public Phone SearchPhone(string _phone)
            => user.PhoneList.FirstOrDefault(p => p.PhoneNumber.ToLower() == _phone.ToLower());
    }
}
