using org.mariuszgromada.math.mxparser;

namespace bolzano;

class Views
{
    public Function firstMenu() {
        Function fn;
        String func;
        do {
            Console.Write("Ingrese la función dependiente de x de la cual se obtendrán las raíces: f(x)=");
            func = Console.ReadLine()!;
            fn = new Function("fn", func, "x");
            fn.setDescription(func);
            if (!fn.checkSyntax() || !func.Contains('x')) {
                Console.WriteLine("La expresión no es válida, intente de nuevo.");
            }
        } while (!fn.checkSyntax() || !func.Contains('x'));
        return fn;
    }

    public double[] secondMenu() {
        double[] values = new double[3];
        char opt;

        do {
            Console.Write("¿Cuenta con un intervalo para la raíz de la función? Si no lo tiene, se tomará por defecto [-1000, 1000] (y/n): ");
            opt = Console.ReadLine()!.ToLower().ElementAt(0);
            if (opt != 'y' && opt != 'n') {
                Console.WriteLine("La opción seleccionada no es válida. Intente de nuevo.");
            }
        } while (opt != 'y' && opt != 'n');
        
        if (opt == 'y') {
            bool valid;

            do {
                Console.Write("Ingrese el límite inferior del intervalo: ");
                valid = Double.TryParse(Console.ReadLine(), out values[0]);
                if (!valid) {
                    Console.WriteLine("El número no es válido. Intente de nuevo.");
                }
            } while (!valid);

            do {
                Console.Write("Ingrese el límite superior del intervalo: ");
                valid = Double.TryParse(Console.ReadLine(), out values[2]);
                if (!valid || values[0] >= values[2]) {
                    Console.WriteLine("El número no es válido. Intente de nuevo.");
                }
            } while (!valid || values[0] >= values[2]);

            values[1] = (values[0] + values[2]) / 2;
        } else {
            values[0] = -1000;
            values[1] = 0;
            values[2] = 1000;
        }

        return values;
    }

    public double thirdMenu() {
        double desErr;
        bool valid;

        do {
            Console.Write("¿Cuál es el error deseado? Ingrese un número entre 0 y 1: ");
            valid = Double.TryParse(Console.ReadLine(), out desErr);
            if (!valid || desErr < 0 || desErr > 1) {
                Console.WriteLine("El valor ingresado no es válido. Intente de nuevo.");
            }
        } while (!valid || desErr < 0 || desErr > 1);

        return desErr;
    }
}