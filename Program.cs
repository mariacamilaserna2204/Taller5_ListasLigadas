using System;

class Program
{
    static void Main(string[] args)
    {
        ListaDoblementeLigada<int> lista = new ListaDoblementeLigada<int>();

        int opcion;
        int numero;

        do
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("   LISTAS DOBLEMENTE LIGADAS");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atras");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar grafico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==================================");

            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un numero: ");
                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        lista.Adicionar(numero);
                        Console.WriteLine("Elemento agregado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Numero no valido.");
                    }
                    break;

                case 2:
                    Console.WriteLine("\nLISTA HACIA ADELANTE:");
                    lista.MostrarAdelante();
                    break;

                case 3:
                    Console.WriteLine("\nLISTA HACIA ATRAS:");
                    lista.MostrarAtras();
                    break;

                case 4:
                    lista.OrdenarDescendente();
                    Console.WriteLine("Lista ordenada descendentemente.");
                    lista.MostrarAdelante();
                    break;

                case 5:
                    lista.MostrarModas();
                    break;

                case 6:
                    lista.MostrarGrafico();
                    break;

                case 7:
                    Console.Write("Ingrese el numero que desea buscar: ");
                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        if (lista.Existe(numero))
                        {
                            Console.WriteLine("El elemento " + numero + " SI existe.");
                        }
                        else
                        {
                            Console.WriteLine("El elemento " + numero + " NO existe.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Numero no valido.");
                    }
                    break;

                case 8:
                    Console.Write("Ingrese el numero que desea eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        if (lista.EliminarUna(numero))
                        {
                            Console.WriteLine("Se elimino una ocurrencia.");
                        }
                        else
                        {
                            Console.WriteLine("El elemento no se encuentra en la lista.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Numero no valido.");
                    }
                    break;

                case 9:
                    Console.Write("Ingrese el numero que desea eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        int cantidad = lista.EliminarTodas(numero);
                        Console.WriteLine("Se eliminaron " + cantidad + " ocurrencia(s).");
                    }
                    else
                    {
                        Console.WriteLine("Numero no valido.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Gracias por utilizar el programa.");
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta. \n Intente de nuevo.");
                    Console.WriteLine("Ingrese las opciones que estan disponibles en el menu.");
                    break;
            }

        } while (opcion != 0);
    }
}
