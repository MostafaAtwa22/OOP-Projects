using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Models
{
    public class User
    {
        #region Private Feilds
        private int id;
        private string? firstName;
        private string? lastName;
        private Gender gender;
        private DateTime addDate;
        private List<Address> addresses;
        private List<Email> emails;
        private List<Phone> phones;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime AddDate => addDate;
        public List<Address> AddressList => addresses;
        public List<Email> EmailList => emails;
        public List<Phone> PhoneList => phones;
        #endregion

        #region Constructors
        public User()
        {
            this.id = 0;
            this.firstName = this.lastName = "Unkwon";
            this.gender = Gender.Male;
            this.addDate = DateTime.Now;
            this.addresses = new List<Address>();
            this.emails = new List<Email>();
            this.phones = new List<Phone>();

        }
        public User(int id, string firstName, string lastName, Gender gender)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.addDate = DateTime.Now;
            this.addresses = new List<Address>();
            this.emails = new List<Email>();
            this.phones = new List<Phone>();
        }
        #endregion

        #region Some overrided Method
        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not User)
                return false;

            User? user = obj as User;
            return this.id == user.id &&
                   this.firstName == user.firstName &&
                   this.lastName == user.lastName &&
                   this.gender == user.gender;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash *= 7 + id.GetHashCode();
            hash *= 7 + firstName.GetHashCode();
            hash *= 7 + lastName.GetHashCode();
            hash *= 7 + gender.GetHashCode();
            return hash;
        }
        #endregion
    }
}
