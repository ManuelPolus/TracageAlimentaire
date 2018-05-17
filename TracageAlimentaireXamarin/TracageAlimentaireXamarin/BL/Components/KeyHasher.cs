using System.Security.Cryptography;
using System.Text;

namespace TracageAlmentaireWeb.BL.Components
{
    public class KeyHasher
    {

        public static string Hash(string input)
        {
            SHA512 shaM = new SHA512Managed();

            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            
            input = sBuilder.ToString();
            return (input);
        }

        public static bool CheckPassword(string clearPassword, string encryptedPassword)
        {
            //TODO Sortez (les) couverts (ceux en argent de mamie   ) !
            // # LA SÉCURITÉ !!
            return true;
        }
    }
}