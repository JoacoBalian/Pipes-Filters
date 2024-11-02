using System;
using System.Collections.Generic;
using Ucu.Poo.Persons;

namespace Library
{
    public class SumaEdadVisitor : IVisitor<Person>
    {
        public int EdadTotal { get; private set; } // Cambiado a private set para control

        public void Visit(Node<Person> nodoInicial)
        {
            EdadTotal = 0; // Inicializar en 0 al iniciar la visita

            // Lista para almacenar los niveles de ancestros
            List<Node<Person>> cola = new List<Node<Person>>(); // Reemplazamos Queue con List
            cola.Add(nodoInicial);

            while (cola.Count > 0)
            {
                List<Node<Person>> nivel = new List<Node<Person>>();
                int tamañoNivel = cola.Count;

                for (int i = 0; i < tamañoNivel; i++)
                {
                    Node<Person> actual = cola[0];
                    cola.RemoveAt(0); // Eliminamos el primer elemento (simulando Dequeue)
                    nivel.Add(actual);

                    // Sumar la edad del nodo actual
                    EdadTotal += actual.Value.Age;
                    

                    // Agregar los padres a la lista para continuar hacia arriba
                    if (actual.PadreIzquierdo != null) cola.Add(actual.PadreIzquierdo);
                    if (actual.PadreDerecho != null) cola.Add(actual.PadreDerecho);
                }

                //niveles.Insert(0, nivel);
            }
        }
    }
}





