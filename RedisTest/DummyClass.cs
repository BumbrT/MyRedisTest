using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    public class DummyClass
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public DummyClass()
        {
            
            Items= new List<DummyItem>(); 
        }
        public List<DummyItem> Items { get; set; }
    }
}
