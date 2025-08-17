using System;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------- FUNCONES - -------------------------------------------");

        ClaseUno cu = new ClaseUno();
        cu.MiMotodoSinRetorno();
        Console.WriteLine("Valor retornado de mi metodo con retorno: " + cu.MiMetodoConRetorno(3));

        Console.WriteLine("---------------------------- FUNCONES POR EXTENSION ------------------------------------");

        ClaseDos cd = new ClaseDos();
        Console.WriteLine("Es valido: " + (cd.EsValido() ? "si" : "no"));

        Console.WriteLine("---------------------------------- DELEGADO -------------------------------------------");

        ClaseTresDelegate<int> claseTresDelegate = new ClaseTresDelegate<int>();

        claseTresDelegate.lista = new List<int>() { 1, 4, 7, 0 };
        claseTresDelegate.ForEach((valor, _) =>
        {
            Console.WriteLine(_);
            valor *= 2;
            Console.WriteLine(valor);
        });

        Console.WriteLine("Campo TipoDelegado: " + claseTresDelegate.CampoTipoDelegado(2));
        Console.WriteLine("Propiedad TipoDelegado: " + claseTresDelegate.PropiedadTipoDelegado(3));
        claseTresDelegate.CampoTipoDelegado = (int parametro) => { return parametro * parametro; };// CAMBIAMOS COMPORTAMIENTO DEL CAMPO TIPO DELEGADO
        Console.WriteLine("Campo TipoDelegado MODIFICADO: " + claseTresDelegate.CampoTipoDelegado(5));
        claseTresDelegate.MetodoAux(12);

        claseTresDelegate.DelegadoAnonimoAction("hola, este es mi delegado anonimo con Action");
        Console.WriteLine("DelegadoAnonimoFunc: " + claseTresDelegate.DelegadoAnonimoFunc(7));

        Console.WriteLine("---------------------------------- ACTION ---------------------------------------------");

        ClaseCuatroAction claseCuatroAction = new();
        claseCuatroAction.Accion();
        claseCuatroAction.Accion = () => { Console.WriteLine("campo 'Accion' modificado"); };
        claseCuatroAction.Accion.Invoke();
        claseCuatroAction.MiFuncionConCallback(() => { Console.WriteLine("Hola, esto lo pase como callback"); });

        Console.WriteLine("--------------------------------- FUNCTION --------------------------------------------");

        ClaseCincoFunc claseCincoFunc = new();
        Console.WriteLine("FuncionRetorno valor: " + claseCincoFunc.FuncionRetorno());
        claseCincoFunc.FuncionRetorno = () => 5*2 ;
        Console.WriteLine("FuncionRetorno modificado: " + claseCincoFunc.FuncionRetorno.Invoke());
        Console.WriteLine("MiFuncionConCallback valor: "+ claseCincoFunc.MiFuncionConCallback(() => 1+2+3+4));//o claseCincoFunc.MiFuncionConCallback<int>(() => 1+2+3+4)

        Console.WriteLine("--------------------------------- PREDICATE -------------------------------------------");
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



/*
 * Metodos funcionales  - nivel intermedio 2 
 * 
 * Para poder trabajar con callbacks tenemos a: delegate, Action, Func<..>, 
*/



/*
 * 1. USANDO DELEGADOS, ACTION Y FUNC: 
 * 
 *          - Cuando creamos un delegate, lo que estamos haciendo es definir un tipo de dato nuevo que tenga una firma establecida(parametros y tipo de retorno), en el cual sera usada en variables, campos o propiedades con dicho tipo para aceptar funciones con la misma firma del delegado definido.
 *          - Un delegate se comporta como un tipo de referencia(es como crear una clase o interfaz), no podemos inicializarla en una sola linea, necesitaremos una propiedad o variable que sea del tipo del delegado creado y asignarle recien una funcion o comportamiento.(tambien podemos cambiar su comportamiento, pero respetando la firma)
 *          
 *    1.1. TIPS:
 *    
 *          Existen delegados anonimos y funciones anonimas, pero, ¿Como identifiicarlos?:
 *          
 *              (0) Un delegado en realidad es como crear una clase o interfaz, y se comportara como tipo de dato para varaibles, campos o propiedades.
 *              (1) Funciones anonimas: Son funciones que no tienen un nombre coma tal y que se pueden asignar a una variable, y se pueden definir tanto con (...) => {...} o delegate(...){...}; 
 *              (2) Delegados anonimos: Son cuando usas el Action<...> o Func<...> asignandole una funcion anonima o expresión lambda. Ej.: Action MiMetodo = () => {....} o  Action MiMetodo = delegate() {...}
 *              (3) Tener en cuenta que no se pueden usar parametros opcionales en esta forma de trabajo con delegate, Action<...> y Func<...>.(pero si hay una forma de usarlas, no recomendado)
 * 
 * 2. CONCLUSIONES: 
 *     
 *      - Los delegados son como crear tipos de datos que firman con tipos de retorno y la cantidad de parametros a una propiedad, campo o variable.
 *      - El uso de Action o Func simplifican la creacion de un delegado.
 *      
 *** ref: https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/delegates/using-delegates
*/


//[MODIFICADOR_ACCESO] [delegate] [TIPO RETORNO] [NombreDelegate]
public delegate void CallbackForEach<T>(T t, int index = 0); // Aqui le digo que mi delegado 'callbackForEach' tendra esta firma
public class ClaseTresDelegate<T>
{

    // DEFINICION DE UN DELEGADO
    //No se puede asignar una funcion anonima o una funcion existente en esta misma linea, pues, es aqui estamos haciendo algo similar a definir una clase o interfaz, del cual, se comporta como TIPO DE DATO para que sea usado por variables, propiedades o campos, en el cual almacene referencias a metodos/comportamientos con dicha firma. 
    public delegate void MiDelegado(string x, string y);// EN LA SIGUIENTE LINEA SE DETALLA LA CREACION Y USO DE MANERA CORRECTA DE UN DELEGADO

    //CREACION DEL TIPO DELEGATE Y CREACION DE VARIABLES, CAMPOS Y PROPIEDADES DE DICHO TIPO
    public delegate int TipoDelegado(int parametro);
    public TipoDelegado CampoTipoDelegado = delegate (int parametro) { return parametro * 2; };   // o (int parametro) => { return parametro * 2; };
    public TipoDelegado PropiedadTipoDelegado { get; set; } = (int parametro) => { return parametro * 2; }; // o delegate (int parametro) { return parametro * 2; };


    // En esta parte no necesitamos de un tipo de delegado con una firma determinada.
    // DELEGADOS ANONIMOS                         FUNCIONES ANONIMAS/LAMBDAS
    public Action<string> DelegadoAnonimoAction = delegate (string a) { Console.WriteLine(a); };  // o (string b, string x) => { Console.WriteLine(b); }; o Console.WriteLine
    public Func<int, int> DelegadoAnonimoFunc = (int a) => a * 2;

    public List<T> lista = new List<T>();

    public void MetodoAux(int a)
    {
        TipoDelegado VariableTipoDelegado = delegate (int parametro) { return parametro * 10; };
        Console.WriteLine("Variable TipoDelegado: " + VariableTipoDelegado(a));
    }

    public void ForEach(CallbackForEach<T> e)
    {
        if (lista == null) throw new Exception("Lista sin inicializar");
        for (int i = 0; i < lista.Count; i++)
        {
            e(lista[i], i);
        }
    }
}

// 2. USANDO ACTION
// ref: https://learn.microsoft.com/es-es/dotnet/api/system.action?view=net-7.0
public class ClaseCuatroAction
{
    //DECLARACION DE UN ACTION 
    // [MODIFICADOR_ACCESO] ACTION<[.,.,.n]?> [NombreAction] = [FUNCION_ANONIMA_MISMA_FIRMA] o [USADO_COMO_PARAMETRO] o [SETEADO_EXTERIOR-O-INTERIOR]
    // n = 0 -> 16, parametros, n representa los tipos 
    public Action Accion = () => Console.WriteLine("Hola, soy una instruccion de Accion ejecutado");// Nota: a esto se le conoce como un delegado anonimo.(1.1. TIPS)
   
    public void MiFuncionConCallback(Action accion)
    {
        accion();// o accion.Invoke();
    }
}

// 3. USANDO FUNC
// ref: https://learn.microsoft.com/es-es/dotnet/api/system.func-1?view=net-7.0
public class ClaseCincoFunc
{
    //DECLARACION DE UN ACTION 
    // [MODIFICADOR_ACCESO] ACTION<[<.,.,.n>?, TResultado! ]> [NombreFunc] = [FUNCION_ANONIMA_MISMA_FIRMA] o [USADO_COMO_PARAMETRO] o [SETEADO_EXTERIOR-O-INTERIOR]
    // n = 0 -> 16, parametros, n representa los tipos 
    // TResultado = Es el tipo de retorno, OBLIGATORIO
    public Func<int> FuncionRetorno = () => 1+1;// Nota: a esto se le conoce como un delegado anonimo.(1.1. TIPS)
    
    public TResult MiFuncionConCallback<TResult>(Func<TResult> funcion)
    {
        return funcion();// o accion.Invoke();
    }
}

// 4. USANDO PREDICATES
//retorna siempre bool

// 5. USANDO EXPRESSIONS 
// su uso es para guardar un arbol de expresiones y que pueda ser traducido a otros lenguajes como  LINQ to SQL o C# to SQL
