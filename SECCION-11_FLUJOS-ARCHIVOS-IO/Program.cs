using System;
using System.Text;

class Program
{

    public static void Main()
    {

        byte[] bufferWithData = Encoding.UTF8.GetBytes("Hola Mundo");// buffer con un tamaño definido 

        using (MemoryStream mst = new MemoryStream())// stream con un tamaño dinamico 
        {
            Console.WriteLine("MemoryStream Antes:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");

            mst.Write(bufferWithData, 0, bufferWithData.Length);// Aqui el stream lee los datos de buffer y los escribe en su buffer dinamico 

            Console.WriteLine("MemoryStream Despues:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");
        }



        byte[] buffer = new byte[1024]; //es un buffer que representa un espacio en memoria de 1024 KB
        byte[] bufferData = Encoding.UTF8.GetBytes("Datos que seran escritos a buffer");
        using (MemoryStream mst = new MemoryStream(bufferData))//el stream ya tiene un tamaño fijo debido al buffer pasado como parametro, 
        {
            Console.WriteLine("MemoryStream Antes:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");

            mst.Read(buffer, 0, bufferData.Length);

            Console.WriteLine("MemoryStream Despues:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");
        }
        string result = Encoding.UTF8.GetString(buffer);
        Console.WriteLine(result);



        //CREACION DE DIRECTORIO 
        string route = Directory.GetCurrentDirectory();


        Console.WriteLine(route);


    }

}