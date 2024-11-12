using System.Security.Principal;
using UserDatabase.Core.Contracts;
using UserDatabase.Core.Models;
using UserDatabase.Core.Repositories;
using UserDatabase.Core.Services;

namespace UserDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository("Server=MIL;Database=Clients;Trusted_Connection=True;TrustServerCertificate=true;");
            IUserService userService = new UserService(userRepository);
            bool running = false;

            while (!running)
            {
                Console.WriteLine("Pasirinkite meniu veiksma: 1. RegisterUser\n2. GetAllUsers\n3. UpdateUser\n4. RemoveUser\n5. UpdatePassword\n6. ActivateUser\n7. DeactivateUser\n8. ListUsersByRole");
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("RegisterUser");
                        Console.WriteLine("Username?");
                        string username = Console.ReadLine();
                        Console.WriteLine("password?");
                        string password = Console.ReadLine();
                        Console.WriteLine("Role?");
                        string role = Console.ReadLine();
                        User newUser;
                        if (role == "Administrator")
                        {
                            newUser = new Admin 
                            {
                                Username = username,
                                Password = password,
                            };
                        } else
                        {
                            newUser = new StandardUser
                            {
                                Username = username,
                                Password = password,
                            };
                        }
                        userService.RegisterUser(newUser);
                        break;
                    case 2:
                        Console.WriteLine("GetAllUsers");
                        foreach (User u in userService.GetAllUsers())
                        {
                            Console.WriteLine(u);
                        }
                        break;
                    case 3:
                        Console.WriteLine("UpdateUser");
                        Console.WriteLine("id?");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Username?");
                        string newUsername = Console.ReadLine();
                        Console.WriteLine("password?");
                        string newPassword = Console.ReadLine();
                        Console.WriteLine("Role?");
                        string newRole = Console.ReadLine();
                        User userUpdated;
                        if (newRole == "Administrator")
                        {
                            newUser = new Admin
                            {
                                UserId = id,
                                Username = newUsername,
                                Password = newPassword,

                            };
                        }
                        else
                        {
                            newUser = new StandardUser
                            {
                                UserId = id,
                                Username = newUsername,
                                Password = newPassword,

                            };
                        }
                        userService.UpdateUser(newUser);
                        break;
                    case 4:
                        Console.WriteLine("RemoveUser");
                        Console.WriteLine("id?");
                        userService.RemoveUser(int.Parse(Console.ReadLine()));
                        break;
                    case 5:
                        Console.WriteLine("UpdatePassword");
                        Console.WriteLine("id?");
                        int userId = int.Parse(Console.ReadLine());
                        Console.WriteLine("old pass?");
                        string oldPass = Console.ReadLine();
                        Console.WriteLine("New pass?");
                        string newPass = Console.ReadLine();
                        User user = userService.GetUser(userId);
                        if (user != null && user.Password == oldPass)
                        {
                            userService.UpdatePassword(userId, newPass);
                        }
                        break;
                    case 6:
                        Console.WriteLine("ActivateUser");
                        Console.WriteLine("id?");
                        userService.ActivateUser(int.Parse(Console.ReadLine()));
                        break;
                    case 7:
                        Console.WriteLine("DeactivateUser");
                        Console.WriteLine("id?");
                        userService.DeactivateUser(int.Parse(Console.ReadLine()));
                        break;
                    case 8:
                        Console.WriteLine("ListUsersByRole");
                        Console.WriteLine("roles: Administrator/StandardUser");
                        foreach (User u in userService.ListUsersByRole(Console.ReadLine()))
                        {
                            Console.WriteLine(u);
                        }
                        break;
                    default:
                        running = true;
                        break;

                }
            }
        }
    }
}
