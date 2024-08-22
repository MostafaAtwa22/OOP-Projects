namespace Contact_Manager_Application.Models
{
    public class Email : AdditionalData
    {
        private string email;
        public string EmailAddress { get => email; set => email = value; }

        public Email() 
        {
            email = "Nothing@gmail.com";
        }

        public Email(string email, string type, string description)
            :base(type, description)
        {
            this.email = email;
        }

        public override string ToString()
        {
            return $"[Email : {email}, {base.ToString()}]";
        }
    }
}
