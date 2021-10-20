using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans.Controllers
{
    public interface IBaseController<T>
    {
        public List<T> Collection { get; set; }
        void GetModelFromFile(string path);
    }
}
