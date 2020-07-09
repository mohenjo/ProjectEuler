using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PE011
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(@"C:\Users\haenn\source\repos\ProjectEuler\PE011\input\PE011.txt");
            //matrix.DisplayGrid();
            Console.WriteLine(matrix.GetMaxMultuipleVale()); // 70600674
            Console.ReadKey();
        }

    }
  
}
