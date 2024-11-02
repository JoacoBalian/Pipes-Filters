using System;
using System.Text.Json.Serialization;
using Library;
using Ucu.Poo.Persons;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
        
            
            // Crear personas
            Person AbueloMaterno = new Person("Óscar", "Tabárez", new DateOnly(1965, 03, 2)); 
            Person AbuelaMaterna = new Person("Susana", "Gimenez", new DateOnly(1970, 01, 29));  
            Person AbueloPaterno = new Person("Luis", "Suarez", new DateOnly(1969, 09, 18)); 
            Person AbuelaPaterna = new Person("Juana", "de Ibarbourou", new DateOnly(1971, 01, 27)); 
            Person Padre = new Person("Franco", "Colapinto", new DateOnly(1998, 12, 20)); 
            Person Madre = new Person("Emilia", "Mernes", new DateOnly(2000, 12, 15)); 
            Person nieto = new Person("Agustin", "Casanova", new DateOnly(2022, 08, 09)); 
            
            // Crear nodos de personas
            Node<Person> abueloMNode = new Node<Person>(AbueloMaterno);
            Node<Person> abuelaMNode = new Node<Person>(AbuelaMaterna);
            Node<Person> abueloPNode = new Node<Person>(AbueloPaterno);
            Node<Person> abuelaPNode = new Node<Person>(AbuelaPaterna);
            Node<Person> PadreNode = new Node<Person>(Padre);
            Node<Person> MadreNode = new Node<Person>(Madre);
            Node<Person> nietoNode = new Node<Person>(nieto);

            
            PadreNode.PadreIzquierdo = abueloPNode;
            PadreNode.PadreDerecho = abuelaPNode;
            
            MadreNode.PadreDerecho = abuelaMNode;
            MadreNode.PadreIzquierdo = abueloMNode;

            nietoNode.PadreDerecho = MadreNode;
            nietoNode.PadreIzquierdo = PadreNode;

           
            // árbol 
            SumaEdadVisitor visitor = new SumaEdadVisitor(); 
            visitor.Visit(nietoNode);
            Console.WriteLine($"La suma de edades es: {visitor.EdadTotal}");
            
            HijoMayorVisitor visitorMayor = new HijoMayorVisitor();
            visitorMayor.Visit(nietoNode);
            Console.WriteLine($"El mayor es: {visitorMayor.HijoMayor.NombreCompleto}");
            
            NombreMasLargoVisitor visitorNombre = new NombreMasLargoVisitor();
            visitorNombre.Visit(nietoNode);
            foreach (Person persona in visitorNombre.PersonasNombreCompletoMasLargo)
            {
                Console.WriteLine($"Quien tiene el nombre más largo es: {persona.Name} {persona.FamilyName}");
            }

            
            
            // Mostrar la jerarquía desde el hijo hacia arriba
            Tree tree = new Tree();
            tree.MostrarJerarquia(nietoNode);
        }
    }
}