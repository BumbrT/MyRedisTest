using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;
namespace RedisTest
{
    static class IOCTest
    {
        public static ServiceContainer Container { get; set; }
        static IOCTest()
        {
            var containerIoc = new LightInject.ServiceContainer();
            IOCTest.Container = containerIoc;
            var item = new IOCTestItem();
            containerIoc.Register<IIOCTestItem>(x => item);
        }
    }


}
