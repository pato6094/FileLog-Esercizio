using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FileLog
{
    internal class Program
    {
       public static List<Persona> personaList = new List<Persona>();
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Che cosa desidera fare? Premere 1 per inserire nuovo utente o premere 2 per stampare la lista utenti");

                string x = Console.ReadLine();
                if(int.Parse(x) == 2)
                {
                    StampaPersona();
                    Log("Ho stampato persone");
                }

                else if  (int.Parse(x) == 1)
                {
                    string nome = Console.ReadLine();
                    string cognome = Console.ReadLine();

                    Persona persona = new Persona(nome,cognome);
                    personaList.Add(persona);

                    Console.WriteLine("Persona Aggiunta");
                    Log($"Ho aggiunto una persona {nome} {cognome}");
                } 

            }





        }

        public static void Log(string testo)
        {
           

            string data = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            File.AppendAllText("C:\\Users\\cuffi\\Desktop\\Log.txt", testo+" "+data+"\n");


        }
        public static void StampaPersona()
        {
            foreach(var persona in personaList)
            {
                Console.WriteLine(persona.Nome);
                Console.WriteLine(persona.Cognome);
            }
        }
    }
   
    public class Persona
    {
        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public string Nome { get; set; }
        public string Cognome { get; set; }


        
    } 

    

}
