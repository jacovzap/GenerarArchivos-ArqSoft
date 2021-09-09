using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace GenerarArchivos
{
    class FileProcesses
    {

        public void addTasksToTheList(StreamWriter file)
        {
            Console.Write("¿Cuantas tareas desea añadir en la lista?:");
            int numberOfTasks = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Añada las tareas a la lista:");
            for (int i = 1; i <= numberOfTasks; i++)
            {
                Console.Write("- ");
                string mensaje = Console.ReadLine();
                file.WriteLine("- " + mensaje);
            }
        }

        public string[]  readAndShowListOfFilesNames()
        {
            string[] filesName = File.ReadAllLines("lists.txt");
            for (int i = 0; i < filesName.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {filesName[i]}");
            }
            return filesName;
        }

        public void createToDoList()
        {
            Console.Clear();

            Console.WriteLine("-----Creando una nueva Lista de Tareas ----");
            Console.Write("Introduce el nombre de la lista:");
            string toDoListName = Console.ReadLine();

            Console.Write("Añade una breve descripcion:");
            string toDoListDescription = Console.ReadLine();

            StreamWriter file = new StreamWriter($"{toDoListName}.txt");
            file.WriteLine($"-------- {toDoListName} --------");
            file.WriteLine($"Descripcion: {toDoListDescription}");

            addTasksToTheList(file);
            file.Close();

            StreamWriter fileWithTheNameOfFiles = File.Exists("lists.txt") ? File.AppendText("lists.txt") : new StreamWriter("lists.txt");
            fileWithTheNameOfFiles.WriteLine(toDoListName);
            fileWithTheNameOfFiles.Close();

            Console.WriteLine("Lista creada con exito!!");
            Console.ReadKey();
        }

        public void seeToDoList()
        {
            Console.Clear();
            Console.WriteLine("-----Ver Lista de Tareas----");
          
            if (File.Exists("lists.txt"))
            {

                string[] filesName = readAndShowListOfFilesNames();
                Console.Write("Seleccione una lista:");
                int selectedFilePosition = Convert.ToInt16(Console.ReadLine());

                if (selectedFilePosition > filesName.Length || selectedFilePosition < 1)
                {
                    Console.WriteLine("Opcion invalida!");
                }
                else
                {
                    StreamReader selectedFile = new StreamReader($"{filesName[selectedFilePosition - 1]}.txt");
                    string fileContent = selectedFile.ReadToEnd();
                    Console.WriteLine("\n" + fileContent);

                    Console.Write("¿Desea añadir tareas a la lista? (si/no):");
                    string addTasksOption = Console.ReadLine();
                    selectedFile.Close();

                    if (addTasksOption == "si")
                    {
                        StreamWriter file = File.AppendText($"{filesName[selectedFilePosition - 1]}.txt");

                        addTasksToTheList(file);
                        file.Close();
                        Console.WriteLine("...Tareas Añadidas!!");
                    }
                    else
                    {
                        if (addTasksOption != "no")
                        {
                            Console.WriteLine("Opcion invalida!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Actualmente no existen listas para mostrar.");
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }


        public void deleteToDoList()
        {
            Console.Clear();
            Console.WriteLine("----- Borrar Lista de Tareas ----");

            if (File.Exists("lists.txt"))
            {
                string[] filesName = readAndShowListOfFilesNames();

                Console.Write("Seleccione la lista a borrar:");
                int selectedFilePosition = Convert.ToInt16(Console.ReadLine());

                if (selectedFilePosition > filesName.Length || selectedFilePosition < 1)
                {
                    Console.WriteLine("Opcion invalida!");
                }
                else
                {
                    File.Delete($"{filesName[selectedFilePosition - 1]}.txt");
                    File.WriteAllLines("lists.txt", File.ReadLines("lists.txt").Where(line => line != filesName[selectedFilePosition - 1]).ToList());
                    Console.WriteLine("Lista Eliminada");
                }

            }
            else
            {
                Console.WriteLine("Actualmente no existen listas para borrar.");
            }
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
