//-------------------------------------------------------------------------
// <copyright file="Person.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------
using System;

namespace Ucu.Poo.Persons
{
    /// Esta clase representa una persona con clase y apellido.
    public class Person
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public DateOnly BirthDate { get; set; }

        public Person(string name, string familyName, DateOnly birthDate)
        {
            this.Name = name;
            this.FamilyName = familyName;
            this.BirthDate = birthDate;
        }


        public string NombreCompleto
        {
            get { return $"{this.Name + " " + this.FamilyName}"; }
        }


        public int Age
        {
            get
            {

                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (today.Month < this.BirthDate.Month ||
                    (today.Month == this.BirthDate.Month && today.Day < this.BirthDate.Day))
                {
                    age -= 1;
                    return age;
                }

                return age;
            }
        }



    }
}   
