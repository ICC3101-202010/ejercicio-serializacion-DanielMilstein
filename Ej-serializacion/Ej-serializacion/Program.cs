using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ejserializacion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Stream stream = new FileStream("Persons.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            List<Person> persons = new List<Person>();
            int op = 0;
            while (op != '5')
            {

            
                Console.WriteLine("Menu");
                Console.WriteLine("1. Crear Persona");
                Console.WriteLine("2. Ver personas");
                Console.WriteLine("3. Cargar personas");
                Console.WriteLine("4. Guardar personas");
                Console.WriteLine("5. Salir");
                op = Console.Read();

                if (op == '1')
                {
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();
                    Console.Write("Edad: ");
                    string edad = Console.ReadLine();
                    int age = Convert.ToInt32(edad);
                    Person daniel = new Person(nombre, apellido, age);
                    persons.Add(daniel);
                }

                else if (op == '2')
                {

                }

                else if (op == '3')
                {
                    
                }
                
                else if (op == '4')
                {
                    Almacenar(stream, persons);
                }
                
                
            }







        }

        public static void Almacenar(Stream stream, List<Person> persons)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, persons);
            stream.Close();


        }

        public static List<Person> Cargar(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            List<Person> persons = (List<Person>)formatter.Deserialize(stream);
            stream.Close();

            return persons;




        }
    }
}
