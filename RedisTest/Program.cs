using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using System.Reflection;
using LightInject;
using System.Security.Claims;
namespace RedisTest
{
    public static class DummExtensions
    {
        public static void storeContext<T>(this DummyClass dummyObject, IRedisClient client, T ctx)
        {
            var typedClient = client.As<T>();
            typedClient.Store(ctx);
            var item = IOCTest.Container.GetInstance<IIOCTestItem>();
            IOCTest.Container.GetInstance<IIOCTestItem>();
            IOCTest.Container.GetInstance<IIOCTestItem>();
            Console.WriteLine("got item");
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            //*** ioc test ****/
           //var identity = new DummExtensions() ;
            ClaimsIdentity i;
            ClaimTypes

            /*** redis test *///
            var  container = new LightInject.ServiceContainer();
            var pool = new BasicRedisClientManager(0, "localhost:6380");
            container.Register<IRedisClientsManager>(x => pool,
                new PerContainerLifetime());
            using (var client = container.GetInstance<IRedisClientsManager>().GetClient())
            {
                
                //client.set
                var dummyClient = client.As<DummyClass>();
                
                var dummyObject = new DummyClass() { Id = dummyClient.GetNextSequence(), Value = "ggwp" };
                long id = dummyObject.Id;

                dummyObject.Items.Add(new DummyItem() { Name = "i1" });
                dummyObject.Items.Add(new DummyItem() { Name = "i2" });
                dummyClient.Store(dummyObject);
                dummyClient.ExpireIn(id, TimeSpan.FromMinutes(30));
                dummyClient.Delete(dummyObject);
                var obj = dummyClient.GetById(id);
                id = 1;
                var obj2 = dummyClient.GetById(10);
                dummyClient.ExpireIn(11, TimeSpan.FromMinutes(20));
                var contextClient = client.As<DummyContext>();
                var context1 = new DummyContext() { Id = 1 };
                contextClient.Store(context1);
                var context2 = new DummyExtendedContext() { Id = 2 , ItWorks = "true"};
                //contextClient.Store(context2);
                obj.storeContext(client, context2);

                var sessionClient = client.As<HttpSession>();
                var session = new HttpSession() { Name = "hehehey" };
                sessionClient.Store(session);
                Console.WriteLine(obj.Id);
                Console.ReadLine();
            }

            //using (var cache = pool.GetCacheClient())
            //{
            //    var dc = cache.Add<DummyClass>()
            //}
        }
    }
}
