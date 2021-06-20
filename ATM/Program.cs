using System;
using System.Collections.Generic;
using ViewLayer;
using B0Layer;

namespace C_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            View view = new View();
            view.loginScreen();

            
            
            List<string> strList = new List<string>();
            strList.Add("Test");
            strList.Add("Of");
            strList.Add("NetCore");

            foreach(var str in strList){
                Console.WriteLine(str);
            }
        }
    }
}
