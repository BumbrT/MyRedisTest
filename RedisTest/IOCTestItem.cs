using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    class IOCTestItem : IIOCTestItem
    {
        public IOCTestItem()
        {
            Console.WriteLine("ioc item created");
        }
    }
    public interface IIOCTestItem
    {

    }
}
