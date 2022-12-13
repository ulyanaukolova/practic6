using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace practic6
{
    public class MyDataFile
    {
        public MyDataFile(string name, int price)
        {
            Name = name;
            Price = price;
        

        public string Name { get; set; } = "";
        public int Price { get; set; } = 0;

    }

}
