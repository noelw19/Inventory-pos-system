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
            
            while(true)
            {
                View view = new View();
                //arg 1 to show that it has not been called from an error
                view.loginScreen(1);
                continue;
            }

            
            
            // List<string> strList = new List<string>();
            // strList.Add("Test");
            // strList.Add("Of");
            // strList.Add("NetCore");

            // foreach(var str in strList){
            //     Console.WriteLine(str);
            // }
        }
    }
}
