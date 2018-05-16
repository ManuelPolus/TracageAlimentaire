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
                if (identifiedUser != null)
                {
                    return true;
                }

                return false;
            }
            catch (NullReferenceException nullex)
            {
                Console.WriteLine("no passwurd");
                return false;
            }

        }
    }
}
