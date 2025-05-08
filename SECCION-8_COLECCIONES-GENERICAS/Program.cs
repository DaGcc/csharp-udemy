using System;
using System.Collections.Generic;

// ref0: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/
/**
 * Primero debemos conocer los tipos que existen en c# .net:
 * ref1: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/builtin-types/built-in-types 
 * ref2: http://learn.microsoft.com/es-es/dotnet/csharp/language-reference/builtin-types/default-values
 * 
 * 1. TIPOS INTEGRADOS: 
 * 
 *      1.1. tipos de valor: 
 *           1.1.0. TABLA DE DATOS: 
 *           
 *                  palabras clave (alias tipo c#)    |       Tipo de .NET         |       Default value     |         Values
 *                  bool                              |       System.Boolean       |          false          |         true | false      
 *                  byte                              |       System.Byte          |            0            |         0 a 255     
 *                  sbyte                             |       System.Sbyte         |            0            |         -128 a 123    
 *                  char                              |       System.Char          |           '\0'          |         cualquier caracter Unicode unico     
 *                  decimal                           |       System.Decimal       |           0.0m          |         ±1.0 × 10⁻²⁸ a ±7.9 × 10²⁸ (precisión ~28-29 dígitos)     
 *                  double                            |       System.Double        |           0.0d          |         ±5.0 × 10⁻³²⁴ a ±1.7 × 10³⁰⁸ (precisión ~15-16 dígitos)    
 *                  float                             |       System.Single        |           0.0f          |         ±1.5 × 10⁻⁴⁵ a ±3.4 × 10³⁸ (precisión ~7 dígitos)     
 *                  int                               |       System.Int32         |            0            |         -2,147,483,648 a 2,147,483,647     
 *                  uint                              |       System.UInt32        |            0            |         0 a 4,294,967,295     
 *                  nint                              |       System.IntPtr        |            0            |         Depende de la plataforma (calculada en tiempo de ejecución)     
 *                  nuint                             |       System.UIntPtr       |            0            |         Depende de la plataforma (calculada en tiempo de ejecución)     
 *                  long                              |       System.Int64         |            0L           |         -9.223.372.036.854.775.808 a 9.223.372.036.854.775.807     
 *                  ulong                             |       System.UInt64        |            0            |         0 a 18.446.744.073.709.551.615     
 *                  short                             |       System.Int16         |            0            |         -32 768 a 32 767     
 *                  ushort                            |       System.UInt16        |            0            |         0 a 65.535     
 *              
 *           NT1: no confundirnos con las diferencias que hay en sus tipos de datos y wrappers en c# .net, pues en por ejemplo en java funciona de manera diferenete 
 *           ej: 
 *           int !=  Integer, pues int es un tipo de dato primitivo e Integer es un objeto wrapper con valor por defecto "null",
 *           mientras que en c# .net int == System.Int32, pues int solo representa un alias para Int32. 
 *           
 *           NT2 : todos los tipos de valor son estructuras(struct), excepto string(alias) o String(wrapper), que es una clase(class) por eso string|String puede ser "null"
 *           
 *          1.1.1. tuplas 
 *          1.1.2. enumeracion 
 *          1.1.3. struct
 *           
 *     1.2. tipos de referencia: 
 *          1.2.0. TABLA: 
 *                 
 *                 plabras clave (alias tipo c#)     |      Tipo de NET           |       Default value  
 *                 object                            |      System.Object         |       null
 *                 string                            |      System.String         |       null
 *                 dynamic                           |      System.Object         |       null
 *                 
 *                
 *                Los string son "tipo de referencia" por la siguientes razones:
 *                 
 *                              (*) Su tamaño no es fijo, ya que puede ser extramadamente grante a comparacion de los tipo de valor(que tienen un tamaño fijo), por ende,no va en el "stack" si no en el "heap"(monton), por temmas de optimos. 
 *                                  Y los tipos de valor suelen ser pequeños y de tamaño fijo, por eso van en el stack.
 *                                
 *                              (*) inmutabilidad, cada modificacion/asignacion a un valor string es una creacion nueva de un objeto string en el heap, lo que cambia es la referencia(puntero).
 *                             
 *                              
 *                              
 *    NT3: Aparte de los tipos integrados, Las palabras clave siguientes se usan para "declarar" tipos de referencia:
 *                           class
 *                           interface
 *                           delegate
 *                           record
 *                 
 *          
 *  2. TIPOS DE CONVERSION:
 *     2.1. Conversion inplicita
 *     2.2. Conversion explicita: Expresión Cast (T)E || as[ E as T : E is T ? (T)(E) : (T)null ],
 *     2.3. Boxing => es cuando se convierte un "tipo de valor" a "object" : [tipo de valor => object], puede ser implicito o explicito. Ej: int a = 1; object obj = a; la conversion de Boxing copia el valor de "a" al objeto "obj". ref4.2 
 *     2.4. Unboxing => es cuando se convierte un tipo "object" a un "tipo de valor" : [object => tipo de valor], aqui necesariamente tiene que ser explicito. Ej: object num1 = 5; int num2 = 3; object result = (int)num1 + num2;tenemos que convertir num1 explicitamente. ref4.3
 *     
 * ref3: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/reference-types => explica la diferencia entre tipos de valor y tipos de ref
 * ref4: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/builtin-types/numeric-conversions => explica que tipos de casting son permitidos o tipos de conversion numericos         
 * ref4.1 : https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression => explica las formas de conversion existentes en c#, tales como: (T)E, is, as, typeof, aunque algunas de estas son para validar. Revisar...
 * ref4.2 : https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/types/boxing-and-unboxing#boxing => conversion Boxing
 * ref4.3 : https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/types/boxing-and-unboxing#unboxing => conversion Unboxing
 */
namespace Seccion8ColeccionesGenericas
{


    class Program
    {
        static void Main(string[] args)
        {

            // Conversiones explicitas : revisar "ref4
            byte numeroPequenio = 123;
            int numeroGrande = numeroPequenio;// Conversion implicita de tipo byte -> int [tipo pequeño -> tipo grande]


            Derivada derivada = new Derivada();
            Base @base = derivada; // Converison implicita de una clase derivada a una base(padre). Esto tambien es comun cuando trabajamos con Interfaces para aplicar ID 



            // Conversiones implictas : revisar "ref4
            int ValorNumericoGrande = 2147483647;
            Console.WriteLine(ValorNumericoGrande);
            byte ValorNumericoPequeño = (byte)ValorNumericoGrande; //para ello usaremos conversion explicita (T)E, para tipo de valor
            Console.WriteLine(ValorNumericoPequeño); // output
            //NT : una conversion puede o no perder informacion o producir una excepcion "OverFlowException", revisar "ref4"

            BaseDos baseDos = new BaseDos();
            DerivadaDos derivadaDos = (DerivadaDos)baseDos;//o baseDos as DerivadaDos;. En los de tipo referencia se puede usar (T)E y 'as'[E as T: E is T ? (T)(E) : (T)null ].
            DerivadaDos? derivadaTres = baseDos as DerivadaDos;//'as'[E as T: E is T ? (T)(E) : (T)null ], la diferencia aqui esta en que 'as' convierte en una referencia determinada o un "tipo de valor que acepta valores NULL", por ello, debemos controlar el maybe-null con "?" en el E.

            

            // Conversiones Boxing y Unboxing
            int i = 123;      // a value type
            object o = i;     // boxing
            int j = (int)o;   // unboxing



            // Recordemos clases genericos 
            GuardaObjetosGenerico<Base> claseGenerica = new GuardaObjetosGenerico<Base>(6);

            Base miBase3 = new Base() { Propiedad = 9 };
            Base miBase4 = new Base() { Propiedad = 1 };
            Base miBase1 = new Base(5);
            Base miBase2 = new Base(7);

            claseGenerica.GuardarElementos(miBase3);
            claseGenerica.GuardarElementos(miBase4);
            claseGenerica.GuardarElementos(miBase1);
            claseGenerica.GuardarElementos(miBase2);

            
            Console.WriteLine(claseGenerica.ObtenerElemento(2).ToString());

            /**NT: ANTES DE EMPEZAR, ES NECESARIO TENER CONICIMIENTO DE TIPOS INTEGRADOS 
             * 
             * Exsiten 3 tipos de colecciones en c#: 
             *  1. GENERICAS:  => ESTAS TIENEN UN MEJOR RENDIMIENTO Y SON MODERNAS
             *      
             *      1.1. Dictionary
             *      1.2. List
             *      1.3. Queu
             *      1.4. Stack
             *      1.5. sortedList
             * 
             *  2. NO GENERICAS
             *  3. CONCURRENT
             * 
             */

        }

        class Base
        {
            public int Propiedad {get; set;}

            public Base() { }
            public Base(int propiedad) => Propiedad = propiedad; 

            public void Metogo()
            {
               
            }
        }

        class Derivada : Base
        {
            public void Metogoee()
            {

            }
        }


        class BaseDos
        {
            public void Metogo()
            {

            }
        }

        class DerivadaDos : BaseDos
        {
            public void metogoee()
            {

            }
        }


        class GuardaObjetosGenerico<T> where T :  class, new() //struct para tipos primitivos // class para tipo de referencia //  new()  para que se pueda instanciar
        {
            #region campos 

            private int i = 0;
            private T[] matrizElementos ;

            #endregion


            #region constructor
            public GuardaObjetosGenerico(int numeroElementos)
            {
                matrizElementos = new T[numeroElementos];   
            }
            #endregion

            #region metodos

            public void GuardarElementos(T TValue)
            {
                matrizElementos[i] = TValue;
                i++;
            }

            public T ObtenerElemento(int index)
            {
                if (index > matrizElementos.Length) new T();
                return matrizElementos[index];
            }

            #endregion
        }
    }

}