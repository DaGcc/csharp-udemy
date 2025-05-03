


using System;
using OWN_CONTROL_EXCEPTIONS.EXCEPTION_RESPONSE;

/**
 * La mayoria de excepciones derivan de Sistem.Exception
 * Refs:
 * https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/exceptions/
 * https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/exceptions/exception-handling => me enseña filtros 
 * https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/language-specification/exceptions#214-how-exceptions-are-handled
 */

namespace ControlExceptions
{

    /**
     * 
     * catch => sirve como 'controlador de excepciones' o definido como tal
     */
    class Program
    {
        public static void Main(string[] args)
        {


            /*
             Cuando se produce una excepción, Common Language Runtime (CLR) busca el bloque 'catch' que pueda controlar esta excepción. 
             Si el método ejecutado actualmente no contiene un bloque catch, CLR busca el método que llamó el método actual, y así sucesivamente en base al stack. 
             Si no se encuentra ningún bloque catch, CLR finaliza el subproceso en ejecución dandonos como error una 'excepcion no controlada'.
             */
            try
            {
                FlowException flowException = new FlowException();
                flowException.ExceptionC();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                //*Console.WriteLine(e.StackTrace); // Trazo de donde se genero la excepcion y por donde fue cayendo, hasta llegar al final de la pila (LIFO) => DESCOMENTA PARA VER EL TRACE
            }


            try
            {
                FilterException filterException = new FilterException();

                Console.WriteLine("[0: null] [1: con valor]");

                Int32.TryParse(Console.ReadLine(), result: out int r);

                if (r == 0)
                {
                    filterException.Origin(null);
                }

                filterException.Origin(data: "Probando el filtro exception");
                //filterException.FilterExceptionMethod(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            try
            {
                CustomException customException = new CustomException();
                customException.ExceptionA("Con valor");
            }
            catch (CustomOwnerException e)
            {
                Console.WriteLine(e.Message + " - Bloque CustomOwnerException");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - Bloque Exception");
            }
        }

    }


    class FlowException()
    {
        public void ExceptionA()
        {
            throw new Exception("Error en A");
        }
        public void ExceptionB()
        {
            try
            {
                ExceptionA();
            }
            catch (Exception e)
            {

                /* throw e
                 CA2200 => me dice que la informacion de la pila cambiara, por ende el stackTrace tambien cambiara.
                 Dado ello, usar 'throw e;' es una mala practica, porque cambias el stack trace que maneja el trazo de la excepcion, origen - fin, EN LA PILA, es decir: 
                 - throw; conserva el seguimiento de pila original de la excepción, que se almacena en la propiedad Exception.StackTrace. Por el contrario, throw e; actualiza la propiedad StackTrace de e. 
                 Ref: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/statements/exception-handling-statements#the-throw-statement 
                 */
                throw;
            }
        }
        public void ExceptionC()
        {// Aqui no usamos el try-catch, por ende el CRL buscara al metodo que llamo a 'ExceptionC' y se avaluaran cosas
            ExceptionB();
        }
    }


    class FilterException
    {

        public void Origin(string? data)
        {
            FilterExceptionMethod(data);

        }

        public void FilterExceptionMethod(string? message)
        {
            try
            {
                throw new Exception($"{message ?? "parametro nullo"}");
            }
            catch (Exception e) when (message is null)// en este catch, manejamos un mensaje mas personalizado, tambien podemos crear una clase para que tengamos una excepcion especifica y darle nuestros mensajes personalizados.
            {
                throw new Exception(e.Message + " - bloque de filtro"); // Es valido, pues estamos en el mismo trace o impl donde se lanzo la excepcion

            }
            catch (Exception)
            {
                throw; // tambien sirve por si otra excepcion llegase a ocurrir, util porque podemos "cambiar su mensaje" a uno general en base a la logia del metodo
            }
        }

    }



    class CustomException()
    {

        public void ExceptionA(string? data)
        {
            //Console.WriteLine(data.Length); // cambialo por esto para que tede otra expceion de NullReferenceException, pero quita el "?" en el parametro
            Console.WriteLine(data?.Length);

            if (data is null) throw new CustomOwnerException("Mi data fue null");

            throw new Exception("Normal Exception");
        }

    }

    /**
     * Nullable refence types 
     * null state: 
     * - not null
     * - maybe null
     */


}