using System;
namespace Ejserializacion
{
    [Serializable]
    public class Person
    {
        private string Name;
        private string LastName;
        private int Age;


        public Person(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }

        public string GetInfo()
        {
            return ($"Nombre: {Name}\nApellido: {LastName}\nEdad: {Age}");
        }
    }
}
