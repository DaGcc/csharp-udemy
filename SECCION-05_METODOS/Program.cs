public class Program()
{
    public static void Main(string[] args)
    {
        ClaseUno cu = new ClaseUno();
        cu.MiMotodoSinRetorno();
        Console.WriteLine("Valor retornado de mi metodo con retorno: " + cu.MiMetodoConRetorno(3));


        ClaseDos cd = new ClaseDos();
        Console.WriteLine("Es valido: " + (cd.EsValido() ? "si" : "no"));



        ClaseTres<int> claseTres = new ClaseTres<int>();

        claseTres.lista = new List<int>() { 1, 4, 7, 0 };
        claseTres.ForEach((valor) =>
        {
            valor *= 2;
            Console.WriteLine(valor);
        });
    }

}


// Creacion de metodos - nivel basico
public class ClaseUno
{
    // ESTRUCTURA DE UN METODO:
    // [MODIFICADOR DE ACCESO] [TIPO DE RETORNO: Tipo o void] [NOMBRE METODO (UpperCamelCase-PascalCase)] [PARAMETROS..]

    public void MiMotodoSinRetorno()
    {
        Console.WriteLine("Metodo sin retorno ejecutado.");
    }

    public int MiMetodoConRetorno(int parametro)
    {
        return parametro * 2;
    }

}

// Metodos por extencion para una clase - nivel intermedio
public class ClaseDos
{
    public bool Estado;

}
public static class ClaseDosHelper
{
    public static bool EsValido(this ClaseDos cd)
    {
        return cd.Estado;
    }

}



// Metodos funcionales  - nivel intermedio 2 
// Para poder trabajar con callbacks tenemos a: delegate, Action, Func<..>

// 1. USANDO DELEGADOS
// ref: https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/delegates/using-delegates
public delegate void callbackForEach<T>(T t);
public class ClaseTres<T>
{
    public List<T> lista = new List<T>();

    public void ForEach(callbackForEach<T> e)
    {
        if (lista == null) throw new Exception("Lista sin inicializar");
        for (int i = 0; i < lista.Count; i++)
        {
            e(lista[i]);
        }
    }
}

// 2. USANDO ACTION


// 3. USANDO FUNC


