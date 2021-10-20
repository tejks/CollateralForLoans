using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans.Controllers
{
    class BaseController<T>
    {
        public List<T> Collection { get; set; } = new();

        public void WriteCollection()
        {
            if (Collection.Count != 0)
            {
                foreach (T element in Collection)
                {
                    Console.WriteLine(element.ToString());
                }
            }
            else
                Console.WriteLine("Colection is empty");
        }
    }
}
