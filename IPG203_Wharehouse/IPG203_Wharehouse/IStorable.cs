using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public interface IStorable
    {
        void AddStock(int quantity);
        void RemoveStock(int quantity);
        string GetInfo();
    }
}
