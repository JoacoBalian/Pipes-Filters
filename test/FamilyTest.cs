using NUnit.Framework;
using Library;
using Ucu.Poo.Persons;

namespace FamilyTreeTests
{
    [TestFixture]
    public class FamilyTreeTests
    {
        private Node<Person> padreNode;
        private Node<Person> madreNode;
        private Node<Person> hijoNode;
        private Node<Person> nietoNode;
        private SumaEdadVisitor sumaVisitor;
        private HijoMayorVisitor hijoMayorVisitor;
        private NombreMasLargoVisitor nombreMasLargoVisitor;

        [SetUp]
        public void Setup()
        {
            // Crear instancias de personas y nodos como en el programa principal
            var AbueloMaterno = new Person("Óscar", "Tabárez", new DateOnly(1965, 03, 2)); 
            var AbuelaMaterna = new Person("Susana", "Gimenez", new DateOnly(1970, 01, 29));  
            var AbueloPaterno = new Person("Luis", "Suarez", new DateOnly(1969, 09, 18)); 
            var AbuelaPaterna = new Person("Juana", "de Ibarbourou", new DateOnly(1971, 01, 27)); 
            var Padre = new Person("Franco", "Colapinto", new DateOnly(1998, 12, 20)); 
            var Madre = new Person("Emilia", "Mernes", new DateOnly(2000, 12, 15)); 
            var nieto = new Person("Agustin", "Casanova", new DateOnly(2022, 08, 09)); 

            // Crear nodos de personas
            var abueloMNode = new Node<Person>(AbueloMaterno);
            var abuelaMNode = new Node<Person>(AbuelaMaterna);
            var abueloPNode = new Node<Person>(AbueloPaterno);
            var abuelaPNode = new Node<Person>(AbuelaPaterna);
            var PadreNode = new Node<Person>(Padre);
            var MadreNode = new Node<Person>(Madre);
            var nietoNode = new Node<Person>(nieto);

            // Asignar padres
            MadreNode.PadreDerecho = abuelaMNode;
            MadreNode.PadreIzquierdo = abueloMNode;

            PadreNode.PadreIzquierdo = abueloPNode;
            PadreNode.PadreDerecho = abuelaPNode;;

            nietoNode.PadreDerecho = MadreNode;
            nietoNode.PadreIzquierdo = PadreNode;


            // Inicializar visitantes
            sumaVisitor = new SumaEdadVisitor();
            hijoMayorVisitor = new HijoMayorVisitor();
            nombreMasLargoVisitor = new NombreMasLargoVisitor();
        }

        [Test]
        public void TestSumaEdades()
        {
            sumaVisitor.Visit(nietoNode);
            Assert.AreEqual(271, sumaVisitor.EdadTotal);
        }

        [Test]
        public void TestMayor()
        {
            hijoMayorVisitor.Visit(nietoNode);
            Assert.AreEqual("Óscar Tabárez", hijoMayorVisitor.HijoMayor.NombreCompleto);
        }

        [Test]
        public void TestNombreMasLargo()
        {
            nombreMasLargoVisitor.Visit(nietoNode);
            
            // Verificar que las tres personas con el nombre más largo están en la lista
            Assert.AreEqual(3, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo.Count);
            Assert.Contains(hijoNode.Value, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo);
            Assert.Contains(padreNode.Value, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo);
            Assert.Contains(madreNode.Value, nombreMasLargoVisitor.PersonasNombreCompletoMasLargo);
        }
    }
}
