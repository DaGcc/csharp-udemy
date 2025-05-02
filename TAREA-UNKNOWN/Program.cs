namespace Program
{
    public class Porgram
    {
        public static void Main(string[] args)
        {

            Convertor c  = new Convertor();
            var TuplaGradosToRadien = c.GradosToRadien();
            var TuplaRadienToGrados = c.RadienToGrados();
            Console.WriteLine("grado {0} a radiente es : {1}", TuplaGradosToRadien.grados, TuplaGradosToRadien.result);
            Console.WriteLine("radien {0} a grado es : {1}", TuplaRadienToGrados.radien, TuplaRadienToGrados.result);


            Figura cuadrado = new Cuadrado(lado:2);
            Console.WriteLine(cuadrado.CalcularArea());

            Figura triangulo = new Triangulo(altura: 14, @base: 3);
            Console.WriteLine(triangulo.CalcularArea());


        } 
    }

    
    public class Convertor
    {
        public const double PI = Math.PI;

        public double Grados { get; set; } = 180;
        public double Radien { get; set; } = Math.PI;

        public (double grados,double result) GradosToRadien()
        {
            return (
                grados : this.Grados,
                result : ((this.Grados * PI)/180)
            );
        }


        public (double radien, double result) RadienToGrados()
        {
            return (
                radien: this.Radien,
                result: ((180 * this.Radien) / PI)
            );
        } 

    }




    public abstract class Figura
    {
        protected float Lado { get; set; } 
        public abstract float CalcularArea();
    }

    public class Cuadrado : Figura
    {

        public Cuadrado(float lado)
        {
            this.Lado = lado;
        }

        public override float CalcularArea()
        {
            return this.Lado*this.Lado;
        }
    }

    public class Triangulo : Figura
    {

        public float altura;

        public Triangulo(float altura, float @base)
        {
            this.Lado = @base;  
            this.altura = altura;
        }
        public override float CalcularArea()
        {
            return (this.Lado*this.altura) / 2;
        }
    }



    //* los string son tipo de referencia; => se crean espacios en memoria con cada string "cadena de texto", y de esa manera a puntan a diferentes memorias: ejp:
    //string a = "b"; => memoria id : 1 => string es técnicamente un tipo de referencia en .NET, su comportamiento es especial y se parece más al de un tipo de valor en muchos casos. Cuando haces string a = "b";, estás creando una referencia a un objeto de cadena en el montón(heap).
    //string otra = a; => memoria id : 1
    //otra = "hola"; => memorai id : 2 , creo otro espacio en memoria 

    //* los numerios son tipo de valor. y por defecto son 0, por ende no es necesario el '?' a diferencia de los string, que es necesario especificarle si acepta nullos o no  


}