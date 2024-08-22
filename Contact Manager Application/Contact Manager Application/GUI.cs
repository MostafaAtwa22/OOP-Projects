using Contact_Manager_Application.Models;
using Contact_Manager_Application.Services;
using Contact_Manager_Application.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Contact_Manager_Application
{
    public static class GUI
    {
        private static Contact? contact;
        private static UserServices? userServices;

        #region Main Start Service
        public static void Start()
        {
            contact = new Contact();
            int choose;
            do
            {
                Console.WriteLine("\n[0] Exit !!");
                Console.WriteLine("[1] Deal with contact data !!");
                Console.WriteLine("[2] Deal with Users data !!");
                Console.Write("\nEnter the Choice: ");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The End Of the Program !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1:
                        ContactData();
                        break;
                    case 2:
                        UsersData();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid Choice !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (choose != 0);
        }

        #endregion

        #region Contact Data
        private static User UserDetails()
        {
            User user = new User();
            Console.Write("Enter ID: ");
            user.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter First Name: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            user.LastName = Console.ReadLine();

            Console.Write("Enter the Gender (Male | Female): ");
            user.Gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);

            return user;
        }

        private static void DeleteUser()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = contact.DeleteUser(id);
            if (deleted == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The user is deleted !!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("The user is not Exists");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void SearchUser()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            User user = contact.SearchUser(id);
            if (user is not null)
            {
                Console.WriteLine("\n\t---------------------------------------------------------------------------------------------------");
                Console.WriteLine($"\t|  ID   |       First Name     |     Last Name       |   Gender    |            Add Date          |");
                Console.WriteLine("\t---------------------------------------------------------------------------------------------------");
                Console.WriteLine($"\t|   {user.Id,-3} |    {user.FirstName,-16}  |   {user.LastName,-16}  |    {user.Gender,-7}  |   {user.AddDate,-26} |");
                Console.WriteLine("\t---------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The User is not Found !!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void ShowAllUsers()
        {
            Console.WriteLine("\n\t---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\t|  ID   |    First Name        |   Last Name         |   Gender    |            Add Date          |");
            Console.WriteLine("\t|-------|----------------------|---------------------|-------------|------------------------------|");

            foreach (var user in contact.Users)
            {
                Console.WriteLine($"\t|   {user.Id,-3} |    {user.FirstName,-16}  |   {user.LastName,-16}  |    {user.Gender,-7}  |   {user.AddDate,-26} |");
            }
            Console.WriteLine("\t|_______|______________________|_____________________|_____________|______________________________|");
        }

        private static void ContactData()
        {
            int choose;
            do
            {
                Console.WriteLine("\n[0] Exit !!");
                Console.WriteLine("[1] Add User !!");
                Console.WriteLine("[2] Delete User !!");
                Console.WriteLine("[3] Search for a User !!");
                Console.WriteLine("[4] Number of Users !!");
                Console.WriteLine("[5] Show All Users !!");
                Console.Write("\nEnter the Choice: ");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you for dealing with Contact Class !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1:
                        bool added = contact.AddUser(UserDetails());
                        if (added == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("A new User Add !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is a user with Same id is already exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case 2:
                        DeleteUser();
                        break;
                    case 3:
                        SearchUser();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nNumber Of users = {contact.NumberOfUsers()}\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 5:
                        ShowAllUsers();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid Choice !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (choose != 0);
        }
        #endregion

        #region UserData

        #region Adding
        private static Phone PhoneData()
        {
            Phone phone = new Phone();
            Console.Write("Enter the Phone Number : ");
            phone.PhoneNumber = Console.ReadLine();
            Console.Write("Enter the Phone Type : ");
            phone.Type = Console.ReadLine();
            Console.Write("Enter the Phone Discrption : ");
            phone.Descripton = Console.ReadLine();

            return phone;
        }

        private static Address AddressData()
        {
            Address address = new Address();
            Console.Write("Enter the Address : ");
            address.AddressName = Console.ReadLine();
            Console.Write("Enter the Address Type : ");
            address.Type = Console.ReadLine();
            Console.Write("Enter the Address Discrption : ");
            address.Descripton = Console.ReadLine();

            return address;
        }

        private static Email EmailData()
        {
            Email email = new Email();
            Console.Write("Enter the Email : ");
            email.EmailAddress = Console.ReadLine();
            Console.Write("Enter the Email Type : ");
            email.Type = Console.ReadLine();
            Console.Write("Enter the Email Discrption : ");
            email.Descripton = Console.ReadLine();

            return email;
        }

        private static void Adding(UserServices userServices)
        {
            int choose;
            do
            {
                Console.WriteLine("\n[0] Exit !!");
                Console.WriteLine("[1] Add Phone !!");
                Console.WriteLine("[2] Add Address !!");
                Console.WriteLine("[3] Add Email!!");
                Console.Write("\nEnter the Choice: ");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you for dealing with Adding Service !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1:
                        Phone phone = PhoneData();
                        bool AddedPhone = userServices.AddPhone(phone);
                        if (AddedPhone is true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Phone Added !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Phone Number is Already Exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case 2:
                        Address address = AddressData();
                        bool AddedAddress = userServices.AddAddress(address);
                        if (AddedAddress is true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The address Added !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The address Is already exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case 3:
                        Email email = EmailData();
                        bool AddedEmail = userServices.AddEmail(email);
                        if (AddedEmail is true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Email Added !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Email is already exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid Choice !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (choose != 0);
        }
        #endregion

        #region Deleting
        private static bool DeletePhone(UserServices userServices)
        {
            Console.Write("Enter the Phone Number : ");
            string PhoneNumber = Console.ReadLine();
            bool find = userServices.DeletePhone(PhoneNumber);

            return find;
        }

        private static bool DeleteAddress(UserServices userServices)
        {
            Console.Write("Enter the Address : ");
            string address = Console.ReadLine();
            bool find = userServices.DeleteAddress(address);

            return find;
        }

        public static bool DeleteEmail(UserServices userServices)
        {

            Console.Write("Enter the Email : ");
            string email = Console.ReadLine();
            bool find = userServices.DeleteEmail(email);

            return find;
        }

        private static void Deleting(UserServices userServices)
        {
            int choose;
            do
            {
                Console.WriteLine("\n[0] Exit !!");
                Console.WriteLine("[1] Remove Phone !!");
                Console.WriteLine("[2] Remove Address !!");
                Console.WriteLine("[3] Remove Email!!");
                Console.Write("\nEnter the Choice: ");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you for dealing with Delete User Services !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1:
                        bool DeletedPhone = DeletePhone(userServices);
                        if (DeletedPhone is true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("The Phone Deleted !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Phone Is Not exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case 2:

                        bool DeletedAddress = DeleteAddress(userServices);
                        if (DeletedAddress is true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("The address Deleted !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The address is not exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case 3:
                        bool DeletedEmail = DeleteEmail(userServices);
                        if (DeletedEmail is true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("The Email Added !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The email is not exists !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid Choice !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (choose != 0);
        }
        #endregion

        #region Searching
        private static Phone SearchPhone(UserServices userService)
        {
            Phone phone = new Phone();
            Console.Write("Enter the Phone Number : ");
            string _phone = Console.ReadLine();
            phone = userService.SearchPhone(_phone);

            return phone;
        }

        private static Address SearchAddress(UserServices userService)
        {
            Address address = new Address();
            Console.Write("Enter the Address Name : ");
            string _address = Console.ReadLine();
            address = userService.SearchAddres(_address);

            return address;
        }

        public static Email SearchEmail(UserServices userService)
        {
            Email email = new Email();
            Console.Write("Enter the Email : ");
            string _email = Console.ReadLine();
            email = userService.SearchEmail(_email);

            return email;
        }

        private static void Searching(UserServices userServices)
        {
            int choose;
            do
            {
                Console.WriteLine("\n[0] Exit !!");
                Console.WriteLine("[1] Search Phone !!");
                Console.WriteLine("[2] Search Address !!");
                Console.WriteLine("[3] Search Email!!");
                Console.Write("\nEnter the Choice: ");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you for dealing with Search Service !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1:
                        Phone phone = SearchPhone(userServices);

                        if (phone is null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Phone is not found !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine(phone.ToString());
                        }
                        break;
                    case 2:
                        Address address = SearchAddress(userServices);

                        if (address is null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The address is not found !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine(address.ToString());
                        }
                        break;
                    case 3:
                        Email email = SearchEmail(userServices);

                        if (email is null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The email is not found !!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine(email.ToString());
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid Choice !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (choose != 0);
        }
        #endregion

        #region Display
        private static void DisplayUserAdditionalData(UserServices user)
        {
            Console.WriteLine("\n------------------ Address ---------------");
            if (user.User.AddressList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{user.User.FirstName} Has no Address !!!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
                foreach (var address in user.User.AddressList)
                    Console.WriteLine(address);

            Console.WriteLine("\n------------------ Email ---------------");
            if (user.User.EmailList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{user.User.FirstName} Has no Email !!!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
                foreach (var email in user.User.EmailList)
                    Console.WriteLine(email);
            Console.WriteLine("\n------------------ Phone ---------------");
            if (user.User.PhoneList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{user.User.FirstName} Has no Phone !!!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
                foreach (var phone in user.User.PhoneList)
                    Console.WriteLine(phone);
        }
        #endregion

        private static void UsersData()
        {
            Console.Write("Enter the ID OF the user : ");
            int Id = int.Parse(Console.ReadLine());
            User user = contact.SearchUser(Id);
            if (user is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The User is not Found !!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            userServices = new UserServices(user);
            int choose;
            do
            {
                if (user is null)
                    break;
                Console.WriteLine("\n[0] Exit !!");
                Console.WriteLine("[1] Add Data !!");
                Console.WriteLine("[2] Remove Data !!");
                Console.WriteLine("[3] Search Data !!");
                Console.WriteLine("[4] Display User Data !!");
                Console.Write("\nEnter the Choice: ");
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you for dealing with User Datat Services !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1:
                        Adding(userServices);
                        break;
                    case 2:
                        Deleting(userServices);
                        break;
                    case 3:
                        Searching(userServices);
                        break;
                    case 4:
                        Console.WriteLine($"\n{user.FirstName} {user.LastName} Data !!");
                        DisplayUserAdditionalData(userServices);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid Choice !!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (choose != 0);
        } 
        #endregion

    }
}
