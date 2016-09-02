using System;
using DocoptNet;

namespace RavenShowOff
{
    internal class Program
    {
        private const string usage = @"Naval Fate.

    Usage:
      RavenShowOff.exe save <id>
      RavenShowOff.exe load <id>
      RavenShowOff.exe upgrade <app_version>

    Options:
      -h --help     Show this screen.
    ";

        private static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args);
            foreach (var argument in arguments)
                Console.WriteLine($"{argument.Key} = {argument.Value}");
        }
    }
}