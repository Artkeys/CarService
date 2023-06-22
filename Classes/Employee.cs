using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public partial class Employee
    {
        public string pathImage
        {
            get
            {
                string currdir = Directory.GetCurrentDirectory();
                int pos = currdir.LastIndexOf("bin");
                string curr = currdir.Substring(0, pos);

                return $"{curr}\\Resources\\Image\\User\\{img}";
            }

            set
            {
                pathImage = value;
            }
        }
    }
}
