using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MVC_LoginAndRegister
{

    public class Hashing

    {
        NetworkCredential nc = new NetworkCredential();
        public static string EnncryptPassword(string password)
        {
            var mysalt = BCrypt.Net.BCrypt.GenerateSalt();
            password = BCrypt.Net.BCrypt.HashPassword(password, mysalt);
            return password;
        }

    }
}