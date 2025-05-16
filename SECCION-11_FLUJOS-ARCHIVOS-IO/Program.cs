using System;
using System.IO;
using System.Text;

class Program
{

    public static void Main()
    {

        byte[] bufferWithData = Encoding.UTF8.GetBytes("Hola Mundo");// buffer con un tamaño definido 
        
        Console.WriteLine("Uso del \"Write\" del MemoryStream:" );   
        using (MemoryStream mst = new MemoryStream())// stream con un tamaño dinamico 
        {
            Console.WriteLine("MemoryStream Antes:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");

            mst.Write(bufferWithData, 0, bufferWithData.Length);// Aqui el stream lee los datos de buffer y los escribe en su propio buffer dinamico si es que no se paso nada en su constructor

            Console.WriteLine("MemoryStream Despues:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");

            Console.WriteLine( "Valor que se escribio en el Memori stream {0}", Encoding.UTF8.GetString(mst.GetBuffer()));
        }

        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        Console.WriteLine("Uso del \"Read\" del MemoryStream:");
        byte[] buffer = new byte[1024]; //es un buffer que representa un espacio en memoria de 1024 KB
        byte[] bufferData = Encoding.UTF8.GetBytes("Datos que seran escritos a buffer");
        using (MemoryStream mst = new MemoryStream(bufferData))//el stream ya tiene un tamaño fijo debido al buffer pasado como parametro, 
        {
            Console.WriteLine("MemoryStream Antes:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");

            mst.Read(buffer, 0, bufferData.Length);// Aqui el stream lee sus datos y los escribe en el buffer 

            Console.WriteLine("MemoryStream Despues:");
            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");

            Console.WriteLine("MemoryStream nueva posicion con seek:");
            mst.Seek(0, SeekOrigin.Begin);// o   mst.Position =  0; aunque considero que mejor seria usar el Seek  

            Console.WriteLine($"Length   :  {mst.Length}");
            Console.WriteLine($"Position :  {mst.Position}");
            Console.WriteLine($"Capacity :  {mst.Capacity}");
        }
        string result = Encoding.UTF8.GetString(buffer);
        Console.WriteLine(result);



        //CREACION DE DIRECTORIO, PATH Y USO DE FILE STREAM - EN BLOQUE
        //const string path = "C:\\Users\\USER\\Documents\\_Proyectos_net\\C#\\CURSO-UDEMY\\csharp-udemy\\SECCION-11_FLUJOS-ARCHIVOS-IO\\Files";
        const string directoryInput = @"C:\Users\USER\Documents\_Proyectos_net\C#\CURSO-UDEMY\csharp-udemy\SECCION-11_FLUJOS-ARCHIVOS-IO\Files";
        const string fileNameInput = "ESTUDIAR_PUNTOS_SPRIGNBOOT.txt";

        if (!Directory.Exists(directoryInput)) return; 
        
        string pathInput = Path.Combine(directoryInput, fileNameInput);


        
        using (FileStream fsi = new FileStream(pathInput, FileMode.OpenOrCreate, FileAccess.Read))
        {
            const string directory = @"C:\Users\USER\Documents\_Proyectos_net\C#\CURSO-UDEMY\csharp-udemy\SECCION-11_FLUJOS-ARCHIVOS-IO\Files";
            const string fileName = "MI_IO.txt";

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
           
            string pathFile = Path.Combine(directory, fileName);


            using (FileStream fs = new FileStream(pathFile, FileMode.Create))
            {
                byte[] bufferBlock = new byte[1024];
                int bytesRead;

                while ((bytesRead = fsi.Read(bufferBlock, 0, bufferBlock.Length)) > 0)
                {
                    fs.Write(bufferBlock, 0, bytesRead);
                }

            }

        }




    }

}