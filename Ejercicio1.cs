using System;

class Ahorcado
{
    static string[] bancoDePalabras = {
        "algoritmo", "computadora", "variable", "funcion", "bucle",
        "arreglo", "compilador", "programa", "consola", "recursion"
    };

    static void Main(string[] args)
    {
        bool continuar = true;

        Console.WriteLine("JUEGO DEL AHORCADO");
        Console.WriteLine("PAL404 - Grupo 01-02L");

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
                    Console.WriteLine("\nHasta luego");
                    break;
                default:
                    Console.WriteLine("\nOpción inválida");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n----- MENÚ PRINCIPAL -----");
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Ver instrucciones");
        Console.WriteLine("3. Salir");
        Console.Write("Selecciona una opción: ");
    }

    static void MostrarInstrucciones()
    {
        Console.WriteLine("\nINSTRUCCIONES");
        Console.WriteLine("Se selecciona una palabra al azar.");
        Console.WriteLine("Debes adivinarla letra por letra.");
        Console.WriteLine("Tienes un máximo de 6 intentos fallidos.");
        Console.WriteLine("Si fallas 6 veces, pierdes.");
        Console.WriteLine("Ganas si completas la palabra a tiempo.");
    }

    static string SeleccionarPalabra()
    {
        Random rnd = new Random();
        int indice = rnd.Next(0, bancoDePalabras.Length);
        return bancoDePalabras[indice];
    }

    static char[] InicializarEstado(string palabra)
    {
        char[] estado = new char[palabra.Length];
        for (int i = 0; i < palabra.Length; i++)
        {
            estado[i] = '_';
        }
        return estado;
    }

    static void MostrarEstadoPalabra(char[] estado)
    {
        Console.Write("Palabra: ");
        for (int i = 0; i < estado.Length; i++)
        {
            Console.Write(estado[i] + " ");
        }
        Console.WriteLine();
    }

    static bool LetraYaUsada(char[] letrasUsadas, int totalUsadas, char letra)
    {
        for (int i = 0; i < totalUsadas; i++)
        {
            if (letrasUsadas[i] == letra)
                return true;
        }
        return false;
    }

    static void MostrarLetrasUsadas(char[] letrasUsadas, int totalUsadas)
    {
        Console.Write("Letras usadas: ");
        for (int i = 0; i < totalUsadas; i++)
        {
            Console.Write(letrasUsadas[i] + " ");
        }
        Console.WriteLine();
    }

    static bool ActualizarEstado(string palabra, char[] estado, char letra)
    {
        bool encontrada = false;
        for (int i = 0; i < palabra.Length; i++)
        {
            if (palabra[i] == letra)
            {
                estado[i] = letra;
                encontrada = true;
            }
        }
        return encontrada;
    }

    static bool VerificarVictoria(char[] estado)
    {
        for (int i = 0; i < estado.Length; i++)
        {
            if (estado[i] == '_')
                return false;
        }
        return true;
    }

    static void IniciarJuego()
    {
        string palabra = SeleccionarPalabra();
        char[] estado = InicializarEstado(palabra);

        char[] letrasUsadas = new char[26];
        int totalUsadas = 0;
        int intentosFallidos = 0;
        int maxIntentos = 6;
        bool juegoActivo = true;

        Console.WriteLine("\nNUEVA PARTIDA");

        while (juegoActivo)
        {
            Console.WriteLine($"\nIntentos fallidos: {intentosFallidos} / {maxIntentos}");
            MostrarLetrasUsadas(letrasUsadas, totalUsadas);
            MostrarEstadoPalabra(estado);

            Console.Write("Ingresa una letra: ");
            string entrada = Console.ReadLine().ToLower().Trim();

            if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("Entrada inválida. Ingresa solo una letra.");
                continue;
            }

            char letra = entrada[0];

            if (LetraYaUsada(letrasUsadas, totalUsadas, letra))
            {
                Console.WriteLine($"La letra '{letra}' ya fue ingresada.");
                continue;
            }

            letrasUsadas[totalUsadas] = letra;
            totalUsadas++;

            bool acierto = ActualizarEstado(palabra, estado, letra);

            if (!acierto)
            {
                intentosFallidos++;
                Console.WriteLine($"La letra '{letra}' no está en la palabra.");
            }
            else
            {
                Console.WriteLine($"La letra '{letra}' está en la palabra.");
            }

            if (VerificarVictoria(estado))
            {
                MostrarEstadoPalabra(estado);
                Console.WriteLine("\nGANASTE. Adivinaste la palabra.");
                juegoActivo = false;
            }
            else if (intentosFallidos >= maxIntentos)
            {
                Console.WriteLine($"\nPERDISTE. La palabra era: {palabra}");
                juegoActivo = false;
            }
        }
    }
}