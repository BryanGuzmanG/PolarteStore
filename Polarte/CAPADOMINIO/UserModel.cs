using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPAACCESOADATOS;

namespace CAPADOMINIO
{
    public class UserModel
    {
        UserDao userDao = new UserDao();

        //Attributes
        private int UserID;
        private string UserName;
        private string Password;
        private string Nombre;
        private string Apellidos;
        private string Rol;
        private string Email;

        public UserModel(int userID, string userName, string password, string nombre, string apellidos, string rol, string email)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Nombre = nombre;
            Apellidos = apellidos;
            Rol = rol;
            Email = email;
        }

        public UserModel() { }
        //Methods
        public string editUserProfile()
        {
            try
            {
                userDao.editProfile(UserID, UserName, Password, Nombre, Apellidos, Email);
                LoginUser(UserName, Password);
                return "Your profile has been successfully updated";
            }
            catch (Exception ex)
            {
                return "Username is already registered, try another";
            }
        }

        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

    }
}
