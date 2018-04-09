
namespace TracageAlmentaireWeb.BL.Components
{
    public class PasswordHasher
    {
        public static bool CheckPassword(string clearPassword, string encryptedPassword)
        {
           
            //TODO: rédiger la méthode.
            return encryptedPassword ==clearPassword;
        }
    }
}