using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorano_sistema
{
    public interface IReceipt
    {
        void Print(Order order);
        void SendByEmail(Order order, string email);
    }
}
