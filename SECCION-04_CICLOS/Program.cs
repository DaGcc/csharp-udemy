using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Program { 
        
    static void Main(string[] args) 
    {

        // int i; //Operando

        //i = 10;
        //Console.WriteLine(i);// imprime 10
        //Console.WriteLine(i);// imprime 10
        //Console.WriteLine(++i);// imprime 11    



        //* FOR

        //List<double> list = new List<double>()
        //{
        //    12,14,6
        //};


        //list.ForEach(x => Console.WriteLine(x));




        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();


        //double[] Notas = new double[4];
        //double acu =0;


        //for (int i = 0; i < Notas.Length;i++)
        //{
        //    try
        //    {

        //        Console.WriteLine("Ingrese la nota nro.{0}:", (i + 1));
        //        Notas[i] = Convert.ToDouble("5");
        //        // acu += Notas[i];    
        //    }catch(Exception e)
        //    {
        //        Console.WriteLine("Error: {0}", e.Message);
        //        i--;
        //    }

        //}


        //for (int i = 0; i < Notas.Length; i++)
        //{
        //    acu += Notas[i];
        //}

        //stopwatch.Stop();

        //Console.WriteLine(acu/Notas.Length);
        //Console.WriteLine("Tiempo transcurrido: " + stopwatch.Elapsed);
        //Console.WriteLine("Termino");



        //* FACTORIAL 



        ulong n, factorial=1;

        Console.WriteLine("Ingrese un número para sacarle el factorial");
        n = Convert.ToUInt64(Console.ReadLine());

        //for (ulong i = 1; i<=n; i++ )
        //{
        //    factorial *= i;
        //}
        //Console.WriteLine(factorial);


        Console.WriteLine(CalculoFactorial(n));


    }


     static public ulong CalculoFactorial(ulong n)
    {
        if (n == 0)
        {
            return 1;
        }

        return n * CalculoFactorial(n - 1);// 2 * (1  * (1) )
    }
    //* 3 : 3 * 2
    //  2 : 2 * 1
    //  1 : 1 * 1
    //  0 : 1
}