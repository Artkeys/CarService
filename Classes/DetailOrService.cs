using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public partial class DetailOrService
    {
        public string pathImageProducts
        {
            get
            {
                string currdir = Directory.GetCurrentDirectory();
                int pos = currdir.LastIndexOf("bin");
                string curr = currdir.Substring(0, pos);

                return $"{curr}\\resources\\image\\product\\{image}";
            }

            set
            {
                pathImageProducts = value;
            }
        }
    }
}
