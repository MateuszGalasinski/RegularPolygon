using RegularPolygonLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonConsoleApplication
{
    class Program
    {
        private static readonly string _fileToSaveName = "SavedPolygonDescription.txt";

        static void Main(string[] args)
        {
            InputParameters parameters = ParseInputParameters(args);
            CalculateRegularPolygon(parameters);

            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }

        private static InputParameters ParseInputParameters(string[] args)
        {
            //check parameters correctness
            if (args.Length != 3)
            {
                throw new InputParametersException($"{args.Length} is not a valid arguments number. There should be 3 arguments.");
            }
            if (!Int32.TryParse(args[0], out int numberOfVertices))
            {
                throw new InputParametersException($"Could not read number of vertexes. {args[0]} is not a valid first argument.");
            }
            if (!Double.TryParse(args[1], out double sideLength))
            {
                throw new InputParametersException($"Could not read polygon side length. {args[1]} is not a valid second argument.");
            }
            if (args[2].ToLowerInvariant() != "d" || args[2].ToLowerInvariant() != "f")
            {
                throw new InputParametersException($"Could not read if should store result in file or display it. {args[2]} is not a valid third argument.");
            }

            //set proper application mode
            ApplicationMode chosenMode;
            if (args[2].ToLowerInvariant() == "d")
            {
                chosenMode = ApplicationMode.ConsoleDisplay;
            }
            else
            {
                chosenMode = ApplicationMode.SaveToFile;
            }

            InputParameters parameters = new InputParameters()
            {
                NumberOfVertices = numberOfVertices,
                SideLength = sideLength,
                Mode = chosenMode
            };
            return parameters;
        }

        private static void CalculateRegularPolygon(InputParameters parameters)
        {
            RegularPolygonFactory factory = new RegularPolygonFactory();
            try
            {
                RegularPolygon polygon = factory.CreatePolygon(parameters.NumberOfVertices, parameters.SideLength, new Vertex(0, 0));
                switch(parameters.Mode)
                {
                    case ApplicationMode.SaveToFile :
                        {
                            SaveToFile(polygon, _fileToSaveName);
                            break;
                        }
                    case ApplicationMode.ConsoleDisplay:
                        {
                            Console.WriteLine(polygon.ToString());
                            break;
                        }
                    default:
                        {
                            WriteErrorLine("Unknown application mode.");
                            break;
                        }
                }
            }
            catch(RegularPolygonFactoryException ex)
            {
                WriteErrorLine(ex.Message);
            }
            catch(Exception ex) //Catches any exception, because cannot handle any kind of exception differently than only inform user about it.
            {
                WriteErrorLine(ex.Message);
            }
        }

        private static void SaveToFile(RegularPolygon polygon, string fileName)
        {
            try
            {
                File.WriteAllText(_fileToSaveName, (polygon.ToString()));
            }
            catch(Exception ex) //Catches any exception, because cannot handle any kind of exception differently than only inform user about it.
            {
                WriteErrorLine(ex.Message);
            }
        }

        private static void WriteErrorLine(string message)
        {
            ConsoleColor before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }
    }
}
