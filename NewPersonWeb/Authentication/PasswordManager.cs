using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPersonWeb.Authentication
{
    public  static class PasswordManager
    {
        public static int ValidTime =300 ;  // 5 min
        public static int PasswordLen = 6; // 6 Character

        private static List<PasswordToken> PasswordTokens;



        public static string AddToken(string UserID)
        {
            try
            {
                if (PasswordTokens is null)
                {
                    PasswordTokens = new List<PasswordToken>();
                }

                // agar user ghablan  token gerefte bashad pak mishavad
                for (int i = PasswordTokens.Count - 1; i >= 0; i--)
                {
                    if (PasswordTokens[i].UserID.Trim() == UserID.Trim())
                    {
                        PasswordTokens.RemoveAt(i);
                    }
                }
                //-------------------------------------------------------


                string Pass = GeneratePassword(PasswordLen);
                PasswordTokens.Add(new PasswordToken { UserID = UserID, Token = Pass });
                return Pass;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public static bool ISValidToken(string UserID , string Pass)
        {
            try
            {
                if (PasswordTokens is null)
                {
                    return false;
                }
                if (UserID is null || Pass is null)
                {
                    return false;
                }
                for (int i = PasswordTokens.Count - 1; i >= 0; i--)
                {
                    var diff = DateTime.Now.Subtract(PasswordTokens[i].CreateDate).TotalSeconds;
                    if (diff > ValidTime)
                    {
                        PasswordTokens.RemoveAt(i);
                    }
                }

                if (PasswordTokens.Count == 0 )
                {
                    return false;
                }

                var result = PasswordTokens.Find(x => x.UserID ==  UserID.Trim()) ;
                if (result is null)
                {
                    return false;
                }

                if (result.Token.Trim() != Pass.Trim())
                {
                    return false;
                }

                var DateDiff = DateTime.Now.Subtract(result.CreateDate).TotalSeconds;
                if (DateDiff > ValidTime)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string GeneratePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


    }





    public class PasswordToken
    {
        public PasswordToken()
        {
            this.CreateDate = DateTime.Now;
        }

        public string UserID { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get;  }
    }

}
