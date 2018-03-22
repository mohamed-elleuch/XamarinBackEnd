using System;
using System.Collections.Generic;
using System.Text;

namespace AppTestMvvm.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public class Color
        {
            public string Colorcode { get; set; }
            public string Colorname { get; set; }
        }
        public class Mesearement
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public int Depth { get; set; }
        }
    }
}
