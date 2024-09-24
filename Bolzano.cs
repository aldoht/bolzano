using org.mariuszgromada.math.mxparser;

namespace bolzano;

class Bolzano
{
    private readonly Function function;
    private readonly Double[] args;
    private readonly double desiredErr;

    public Bolzano(Function function, Double[] args, double desiredErr) {
        this.function = function;
        this.args = args;
        this.desiredErr = desiredErr;
    }

    public void iterar() {
        double err;
        double lastMiddleValue = args[1];
        
        if (args.Length != 3) {
            Console.WriteLine("Error: El arreglo no es del tamaño esperado.");
            return;
        }
        if (!function.checkSyntax() || function.getArgumentsNumber() != 1 || !function.getFunctionName().Equals("fn")) {
            Console.WriteLine($"Error: La función no es válida. El número de argumentos de {function.getFunctionName()} es {function.getArgumentsNumber()}.");
            return;
        }

        Console.WriteLine($"La función es f(x)={function.getFunction("fn").getDescription()}.");
        Console.WriteLine($"Los valores son los siguientes: x_l = {args[0]}, x_m = {args[1]}, x_r = {args[2]}.");
        foreach (double x in args) {
            function.setArgumentValue(0, x);
            Console.WriteLine($"El valor de f({x}) es {function.calculate()}.");
        }

        if ((function.calculate(args[0])*function.calculate(args[1])) < 0) {
            Console.WriteLine("Se tiene que f(x_l)f(x_m) < 0.");
            args[2] = args[1];
            args[1] = (args[0] + args[2]) / 2;
            Console.WriteLine($"Nuevos valores: x_l = {args[0]}, x_m = {args[1]}, x_r = {args[2]}.");
        } else if ((function.calculate(args[0])*function.calculate(args[1])) > 0) {
            Console.WriteLine("Se tiene que f(x_l)f(x_m) > 0.");
            args[0] = args[1];
            args[1] = (args[0] + args[2]) / 2;
            Console.WriteLine($"Nuevos valores: x_l = {args[0]}, x_m = {args[1]}, x_r = {args[2]}.");
        } else {
            Console.WriteLine("Se tiene que f(x_l)f(x_m) = 0.");
            Console.WriteLine($"Se ha encontrado una raíz en el intervalo: x = {args[1]}.");
            return;
        }

        err = Math.Abs((args[1] - lastMiddleValue) / args[1]);

        Console.WriteLine($"Error actual: {err*100}%");

        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

        if (err < desiredErr) {
            Console.WriteLine($"El error aproximado es menor al error deseado, por lo tanto una raíz en el intervalo es x = {args[1]} con un error aproximado del {err*100}%.");
            return;
        }

        iterar();
    }
}