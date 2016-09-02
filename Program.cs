﻿using System;
using DocoptNet;
using Newtonsoft.Json;
using Raven.Client;

namespace RavenShowOff
{
    internal partial class Program
    {
        private static IDocumentSession Session;
        private const string usage = @"Raven Show Off!

    Usage:
      RavenShowOff.exe save
      RavenShowOff.exe load <id>
      RavenShowOff.exe list
      RavenShowOff.exe upgrade <app_version>

    Options:
      save will save Bob M. Smiley
      load <id> will load whichever instance of Bob you want
      list will list all the Bob's
    ";
        const string DatabaseName = "CineSample";

        private static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, exit: true);

            Setup();

            if (arguments["save"].IsTrue)
                SaveBob();

            if (arguments["load"].IsTrue)
                LoadBob(arguments["<id>"].ToString());

            if (arguments["list"].IsTrue)
                ListBobs();

            
        }

        private static void LoadBob(string idOfBob)
        {
            var bob = Session.Load<Person>($"People/{idOfBob}");

            var bobWithThisIdWasFound = bob == null;
            if (bobWithThisIdWasFound)
                Console.WriteLine($"No Bob found for {idOfBob}");
            else
                Console.WriteLine(JsonConvert.SerializeObject(bob));
        }

        private static void ListBobs()
        {
            var allTheBobs = Session.Query<Person>();

            foreach (var bob in allTheBobs)
            {
                Console.WriteLine(JsonConvert.SerializeObject(bob));
            }
        }

        private static void SaveBob()
        {
            var person = new Person("Bob M. Smiley");
            Session.Store(person);
            Console.WriteLine($"Got Id:{person.Id} for Bob.");

            person.PhoneNumbers.Add(new Person.PhoneNumber(404, "123-4588"));

            Session.SaveChanges();
        }

        private static void Setup()
        {
            DocumentStoreHolder.Store.DatabaseCommands.GlobalAdmin.EnsureDatabaseExists(DatabaseName);
            Session = DocumentStoreHolder.Store.OpenSession(DatabaseName);
        }
    }
}