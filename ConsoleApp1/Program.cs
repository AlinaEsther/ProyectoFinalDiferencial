
using IronPython.Hosting;
class DerivativeCalculator
{
    static void Main()
    {
        Console.WriteLine("Calculadora de Derivadas");
        Console.WriteLine("-------------------------");
        // Ingresar la función
        Console.Write("Ingrese la función (por ejemplo, x**2): ");
        string inputFunction = Console.ReadLine();
        // Seleccionar la variable de derivación
        Console.Write("Ingrese la variable de derivación (por ejemplo, x): ");
        string variable = Console.ReadLine();
        // Seleccionar el orden de la derivada
        Console.Write("Ingrese el orden de la derivada (por ejemplo, 1): ");
        int order = Convert.ToInt32(Console.ReadLine());
        // Calcular la derivada
        string derivative = CalculateDerivative(inputFunction, variable, order);
        // Mostrar el resultado
        Console.WriteLine($"La derivada de {inputFunction} con respecto a {variable} de orden {order} es: {derivative}");
        Console.ReadLine(); // Para que la consola no se cierre inmediatamente
    }
    // Función para calcular la derivada utilizando IronPython
    static string CalculateDerivative(string function, string variable, int order)
    {
        var engine = Python.CreateEngine();
        var scope = engine.CreateScope();
        // Definir la función y variable en el ámbito de IronPython
        engine.Execute($"from sympy import symbols, diff; {variable} = symbols('{variable}'); f = {function}");
        // Calcular la derivada
        string derivativeExpression = $"diff(f, {variable}, {order})";
        dynamic result = engine.Execute(derivativeExpression, scope);
        return result.ToString();
    }
}