
using System;

namespace Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Headimgurl { get; set; }
        public string Area { get; set; }
        public int Sex { set; get; }
        public DateTime CreateTime { get; set; }
    }
}
