namespace Contact_Manager_Application.Models
{
    public class Address : AdditionalData 
    {
        private string address;
        public string AddressName { get => address; set => address = value; }
        public Address()
        {
            address = "Cairo";
        }

        public Address(string address, string type, string descripton)
            : base(type, descripton)
        {
            this.address = address;
        }

        public override string ToString()
        {
            return $"[Address : {address}, {base.ToString()}]";
        }
    }
}
