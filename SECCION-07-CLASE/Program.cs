

using static System.Formats.Asn1.AsnWriter;

namespace Seccion7Clase
{

    class Program
    {
        static void Main(string[] args)
        {

            Dia dia = new Dia()
            {
                Date = new DateOnly(2025,04,19)
            };

            Console.WriteLine("DAY: {0}",dia.Date);
            Console.WriteLine("TOMORROW: {0}",dia.Tomorrow);
            Console.WriteLine("YESTERDAY: {0}",dia.Yesterday);

        }

        DateOnly Date;

      

    }


    public class Dia
    {
        /**
         * ESTRUCTURA DE UNA CLASE
         * Refs : 
         * https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/class => que puede contener una clase
         * https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/using-properties
         * 
		 * descriptores de acceso c#
		 *		set; get; init;
		 * modificadores de acceso c#: Ref: https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
		 *      public, private, protected, internal,..etc.
		 * 
		 * NT: Si usamos una implementacion(para una logica adicional) ya sea en el set; o get;, mayormente en set;, debemos considerar el uso de un
		 *     baking-store, pues si get; o set; tiene una implementacion, el otro debe forzosamente pedira tener una implementacion, dejando asi que get; y set; sean abstractas por defecto
		 *
		 *
         * 
         * 
         * CONTROL DE NULL-STATE
         * ref: https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8618)
         * ref: https://learn.microsoft.com/es-es/ef/core/miscellaneous/nullable-reference-types 
         * ref: https://learn.microsoft.com/es-es/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwith-nrt#required-and-optional-properties
         * Null-state => maybe-null & not-null
         * '?' => cambia de  not-null a maybe-null
         * '!' => cambia de maybe-null a not-null
         * 
         * 
		 */



        //USO BASICO 

        //CAMPO => [MODIFICADORES DE ACCESO] [TIPO DE DATO] [NombreDePropiedad]
        private DateOnly _date; //backing-store => lo usamos como respaldo, si es que deseamos implementar logica en los descriptores de acceso 

        //PROPIEDADES => [MODIFICADORES DE ACCESO] [TIPO DE DATO] [NombreDePropiedad] [DESCRIPTOR DE ACCESO]
        public DateOnly Date {
            get => _date;
            set 
            {
                // SETEO DE VALOR A LA PROPIEDAD 'Date' USANDO UN BACKING-STORE - SIEMPRE QUE TENGAMOS UNA IMPL EN SU set; O get;.
                // CON LOGICA ADICIONAL, puedes tambien setear a otras propiedades en esta implementacion, EJ:

                _date = value; // USAMOS EL BACKING STORE ASOCIADO A 'Date'
                this.Yesterday = value.AddDays(-1).ToString(); //LOGICA QUE MODIFICA|SETEA UN VALOR A OTRA PROPIEDAD
                this.Tomorrow = value.AddDays(1).ToString();   //LOGICA QUE MODIFICA|SETEA UN VALOR A OTRA PROPIEDAD
            } 
        }





        // USO DEL DESCRIPTOR CON BACKING STORE, ES DECIR, UN CAMPO Y UNA PROPIEDAD,[PRIVADA & PUBLICA]

        public string _tomorrow = string.Empty; // BUENA PRACTICA, para manejar los non-null
        public string Tomorrow
        {
            /* USO INCORRECTO QUE LLEVA A 'STACKOVERFLOW'
             get => Tomorrow; //ESTO GENERA UN STACKOVERFLOW, PUES SIEMPRE SE EJECUTARA EL GET PARA TRAER EL VALOR DE 'Tomorrow' DE MANERA RECURSIVA

            set
            {
                // ESTO GENERA UN STACKOVERFLOW, PUES EL SET SIEMPRE "SET" DE ESTA PROPIEDAD SIEMPRE SE EJECUTARA-RECCURSIVAMENTE, AL PARECER. PARA ELLO USEMOS UN BACKING STORE
                //Tomorrow = Date.AddDays(1).ToString();
               
            }
            */


            get => _tomorrow;  //** Uso de backing-store para que Yesterday pueda mostrar un valor y evitar el STACKOVERFLOW
            set
            {
                if (value is not null)
                {
                    Console.WriteLine("{0}", value.ToString());
                    _tomorrow = value; //** Uso de backing - store para que Yesterday pueda tener un valor y evitar el STACKOVERFLOW
                }
            }
        }
      

        private string _yesterday = string.Empty; // | private string? _yesterday;
        public string Yesterday
        {
            get => _yesterday;
            set
            {
                
                if (!string.IsNullOrEmpty(value))
                {
                    Console.WriteLine(value);
                    _yesterday = value; // uso de backing-store para que Yesterday pueda mostrar un valor y evitar el STACKOVERFLOW
                }
            }
        }

    }
 


    public class ClaseGenerica<T>
    {

    }
}