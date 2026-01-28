using MyFirstApp.Communication.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstApp.Communication.Response
{
    public class ResponseRegisterBookJson
    {
        public Guid Id { get; set; }
        public  string Title { get; set; }
        public  string Author { get; set; }
        public  string Genre { get; set; }
        public  decimal Price { get; set; }
        public  int Stock { get; set; }
    }
}
