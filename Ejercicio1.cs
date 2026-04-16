using System;

class Ahorcado
{
    static string[] bancoDePalabras = {
        "algoritmo",
        "computadora",
        "variable",
        "funcion",
        "bucle",
        "arreglo",
        "compilador",
        "programa",
        "consola",
        "recursion"
    };

    static void Main(string[] args)
    {
        bool continuar = true;

        Console.WriteLine("║     JUEGO DEL AHORCADO           ║");

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    IniciarJuego();
                    break;
                case "2":
                    MostrarInstrucciones();
                    break;
                case "3":
                    continuar = false;
                    Console.WriteLine("\n¡Hasta luego! ");
                    break;
                default:
                    Console.WriteLine("\n  Opción inválida. Intenta de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("║        MENÚ PRINCIPAL    ║");
        Console.WriteLine("║  1. Jugar                ║");
        Console.WriteLine("║  2. Ver instrucciones    ║");
        Console.WriteLine("║  3. Salir                ║");
        Console.Write("Selecciona una opción: ");
    }

    static void MostrarInstrucciones()
    {
        Console.WriteLine("\n════════════ INSTRUCCIONES ════════════");
        Console.WriteLine(" Se selecciona una palabra al azar.");
        Console.WriteLine(" Debes adivinarla letra por letra.");
        Console.WriteLine(" Tienes un máximo de 6 intentos fallidos.");
        Console.WriteLine(" Si fallas 6 veces, ¡el ahorcado muere!");
        Console.WriteLine(" Ganas si completas la palabra a tiempo.");
    }

    static string SeleccionarPalabra()
    {
        Random rnd = new Random();
        int indice = rnd.Next(0, bancoDePalabras.Length);
        return bancoDePalabras[indice];
    }

    static void IniciarJuego()
    {
        Console.WriteLine("\n[Juego en construcción — Commit A-2]");
    }
}