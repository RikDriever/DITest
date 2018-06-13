using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DITest
{
    public static class MyDataFactory
    {
        public static async Task<MyData> GetDataAsync()
        {
            await Task.Delay(500); // pretend it takes some time to execute this method

            MyData myData = new MyData();
            myData.Name = "Name set using MyDataFactory.GetData() this is want we want to see!";
            return myData;
        }

        public static void GetData(ref MyData myData)
        {
            myData.Name = "Name set using MyDataFactory.GetData(ref MyData myData)";
        }
    }
}
