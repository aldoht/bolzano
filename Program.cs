using org.mariuszgromada.math.mxparser;

namespace bolzano;

class Program
{
    static void Main(string[] args)
    {
        License.iConfirmNonCommercialUse("Aldo Hernandez");
        Views views = new Views();

        Function fn = views.firstMenu();
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

        Double[] vals = views.secondMenu();
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

        Double desiredErr = views.thirdMenu();
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

        Bolzano solution = new Bolzano(fn, vals, desiredErr);
        solution.iterar();

        Console.Write("Presione una tecla para salir...");
        Console.ReadLine();   
    }
}
