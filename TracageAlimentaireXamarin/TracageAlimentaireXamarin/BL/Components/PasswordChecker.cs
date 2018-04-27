using System;
using Tracage.Models;

namespace TracageAlimentaireXamarin.BL.Components
{
    class PasswordChecker
    {
        public static bool CheckPassord(string clear, User identifiedUser)
        {
            try
            {
                //return Checker.Check(identifiedUser.Password,clear);
                return true;
            }
            catch (NullReferenceException nullex)
            {
                Console.WriteLine("no passwurd");
                return false;
            }
           
        }
    }
}
