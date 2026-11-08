using System;
using System.Collections.Generic;

public class ListaDoblementeLigada<T> where T : IComparable<T>
{
    private Nodo<T>? principio;
    private Nodo<T>? final;

    public bool EstaVacia()
    {
        return principio == null;
    }

    // 1. Insert while maintaining ascending order
    public void Adicionar(T dato)
    {
        Ordenar(true);

        Nodo<T> nuevo = new Nodo<T>(dato);

        if (EstaVacia())
        {
            principio = final = nuevo;
            return;
        }

        if (dato.CompareTo(principio!.Dato) <= 0) // <--- Se quitó el paréntesis extra ')'
        {
            nuevo.Siguiente = principio;
            principio.Anterior = nuevo;
            principio = nuevo;
            return;
        }

        if (dato.CompareTo(final!.Dato) >= 0) // <--- Se quitó el paréntesis extra ')'
        {
            nuevo.Anterior = final;
            final.Siguiente = nuevo;
            final = nuevo;
            return;
        }

        Nodo<T>? actual = principio;

        while (actual.Siguiente != null &&
               dato.CompareTo(actual.Siguiente.Dato) > 0)
        {
            actual = actual.Siguiente;
        }

        nuevo.Siguiente = actual.Siguiente;
        nuevo.Anterior = actual;

        actual.Siguiente!.Anterior = nuevo;
        actual.Siguiente = nuevo;
    }

    // 2. Show forward
    public void MostrarAdelante()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo<T>? actual = principio;

        Console.Write("Inicio -> ");

        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }

        Console.WriteLine("Fin");
    }

    // 3. Show backward
    public void MostrarAtras()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo<T>? actual = final;

        Console.Write("Fin -> ");

        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Anterior;
        }

        Console.WriteLine("Inicio");
    }

    // Auxiliary method for sorting in both directions
    private void Ordenar(bool ascendente)
    {
        List<T> datos = new List<T>();

        Nodo<T>? actual = principio;

        while (actual != null)
        {
            datos.Add(actual.Dato);
            actual = actual.Siguiente;
        }

        datos.Sort();

        if (!ascendente)
        {
            datos.Reverse();
        }

        actual = principio;
        int i = 0;

        while (actual != null)
        {
            actual.Dato = datos[i++];
            actual = actual.Siguiente;
        }
    }

    // 4. Sort in descending order
    public void OrdenarDescendente()
    {
        Ordenar(false);
    }

    // 5. Show all trends
    public void MostrarModas()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Dictionary<T, int> frecuencias = new Dictionary<T, int>();

        Nodo<T>? actual = principio; // <--- Se corrigió 'cabeza' por 'principio'

        while (actual != null)
        {
            if (frecuencias.ContainsKey(actual.Dato))
            {
                frecuencias[actual.Dato]++;
            }
            else
            {
                frecuencias[actual.Dato] = 1;
            }

            actual = actual.Siguiente;
        }

        int maximo = 0;

        foreach (var elemento in frecuencias)
        {
            if (elemento.Value > maximo)
            {
                maximo = elemento.Value;
            }
        }

        Console.Write("Moda(s): ");

        foreach (var elemento in frecuencias)
        {
            if (elemento.Value == maximo)
            {
                Console.Write(elemento.Key + " ");
            }
        }

        Console.WriteLine("\nFrecuencia: " + maximo);
    }

    // 6. Show frequency chart
    public void MostrarGrafico()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Dictionary<T, int> frecuencias = new Dictionary<T, int>();

        Nodo<T>? actual = principio;

        while (actual != null)
        {
            if (frecuencias.ContainsKey(actual.Dato))
            {
                frecuencias[actual.Dato]++;
            }
            else
            {
                frecuencias[actual.Dato] = 1;
            }

            actual = actual.Siguiente;
        }

        Console.WriteLine("\nGRAFICO DE OCURRENCIAS");

        foreach (var elemento in frecuencias)
        {
            Console.Write(elemento.Key + " ");

            for (int i = 0; i < elemento.Value; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }

    // 7. Search if exists
    public bool Existe(T dato)
    {
        Nodo<T>? actual = principio;

        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Dato, dato))
            {
                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    // Auxiliary method for disconnecting a node
    private void Desconectar(Nodo<T> actual)
    {
        if (actual.Anterior != null)
        {
            actual.Anterior.Siguiente = actual.Siguiente;
        }
        else
        {
            principio = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente.Anterior = actual.Anterior;
        }
        else
        {
            final = actual.Anterior;
        }

        actual.Anterior = null;
        actual.Siguiente = null;
    }

    // 8. Delete a single occurrence
    public bool EliminarUna(T dato)
    {
        Nodo<T>? actual = principio;

        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Dato, dato))
            {
                Desconectar(actual);
                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    // 9. Delete all occurrences
    public int EliminarTodas(T dato)
    {
        int eliminados = 0;
        Nodo<T>? actual = principio;

        while (actual != null)
        {
            Nodo<T>? siguiente = actual.Siguiente;

            if (EqualityComparer<T>.Default.Equals(actual.Dato, dato))
            {
                Desconectar(actual);
                eliminados++;
            }

            actual = siguiente;
        }

        return eliminados;
    }
}
