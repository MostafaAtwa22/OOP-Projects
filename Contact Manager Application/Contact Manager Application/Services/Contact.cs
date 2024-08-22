using Contact_Manager_Application.Models;

namespace Contact_Manager_Application.Services
{
    public class Contact
    {
        private static int count;
        private List<User> users;

        public List<User> Users => this.users;

        static Contact()
        {
            count = 0;
        }

        public Contact()
        {
            users = new List<User>();
        }

        public bool AddUser(User user)
        {
            if (!users.Any(i => i.Id == user.Id))
            {
                count++;
                users.Add(user);
                return true;
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            
            if (users.Any(i => i.Id == id))
            {
                count--;
                users.RemoveAll(i => i.Id == id);
                return true;
            }
            return false;
        }
        public User SearchUser(int id)
        {
            User? user = users.FirstOrDefault(i => i.Id == id); ;
            return user;
        }

        public int NumberOfUsers() => count;
  
    }
}
