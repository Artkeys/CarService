using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Classes
{
    internal class validPasswordClass
    {
        public static string password_level(string password)
        {
            int flagDigit = 0;
            int flagUpRegistr = 0;
            int flagDownRegistr = 0;
            int sumFlag = 0;

            if (password.Length < 6)
            {
                return "Недопустимый пароль";
            }

            else
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (Char.IsDigit(password, i))
                    {
                        flagDigit = 1;
                    }

                    if (Char.IsUpper(password, i))
                    {
                        flagUpRegistr = 1;
                    }

                    if (Char.IsLower(password, i))
                    {
                        flagDownRegistr = 1;
                    }
                }

                sumFlag = flagDigit + flagUpRegistr + flagDownRegistr;

                if (sumFlag == 1)
                {
                    return "Ненадежный пароль";
                }
            }

            if (sumFlag == 2)
            {
                return "Слабый пароль";
            }

            else if (sumFlag == 3)
            {
                return "Надежный пароль";
            }

            else
            {
                return default;
            }
        }
    }
}
