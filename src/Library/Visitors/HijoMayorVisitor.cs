using System;
using System.Collections.Generic;
using Library;
using Ucu.Poo.Persons;

public class HijoMayorVisitor :IVisitor<Person>
{
    public Person HijoMayor { get; set; }
    
    public void Visit(Node<Person> node)
    {
        if (HijoMayor is null) //se inicializa hijoMayor
        {
            HijoMayor = node.Value;
        }

        // Lista para almacenar los niveles de ancestros
        List<Node<Person>> cola = new List<Node<Person>>(); 
        cola.Add(node);

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
                if (actual.Value.Age > HijoMayor.Age)
                {
                    
                    HijoMayor = actual.Value;
                }

                // Agregar los padres a la lista para continuar hacia arriba
                  if (actual.PadreIzquierdo != null) cola.Add(actual.PadreIzquierdo);
                  if (actual.PadreDerecho != null) cola.Add(actual.PadreDerecho);
            }

            
        }
    }
}

    


