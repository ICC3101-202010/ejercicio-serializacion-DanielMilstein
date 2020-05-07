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
            
            List<Person> persons = new List<Person>();
            int op = 0;
            string a = "Persons.bin";
            while (op != '5')
            {

            
                Console.WriteLine("Menu");
                Console.WriteLine("1. Crear Persona");
                Console.WriteLine("2. Ver personas");
                Console.WriteLine("3. Cargar personas");
                Console.WriteLine("4. Guardar personas");
                Console.WriteLine("5. Salir");
                op = Console.Read();
                Console.Write("\n");
                if (op == '1')
                {
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();
                    Console.Write("Edad: ");
                    bool num = false;
                    int age = 0;
                    while (!num)
                    {

                        string edad = Console.ReadLine();

                        try
                        {
                            age = Convert.ToInt32(edad);
                            num = true;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Edad debe ser un numero");
                            Console.Write("Edad: ");
                        }
                    }
                    
                    Person x = new Person(nombre, apellido, age);
                    persons.Add(x);
                }

                else if (op == '2')
                {
                    foreach (Person person in persons)
                    {
                        Console.WriteLine(person.GetInfo()); 

                    }
                }

                else if (op == '3')
                {
                    persons = Cargar(a);
                }
                
                else if (op == '4')
                {
                    Almacenar(persons, a);
                }
                
                
            }







        }

        public static void Almacenar(List<Person> persons, string a)
        {
            
            Stream stream = new FileStream(a, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, persons);
            stream.Close();
            


        }

        public static List<Person> Cargar(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            List<Person> persons = (List<Person>)formatter.Deserialize(stream);
            stream.Close();

            return persons;




        }
    }
}
