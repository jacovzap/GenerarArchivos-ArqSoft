using System;
using System.Collections.Generic;
using System.Text;

namespace GenerarArchivos
{
    class Menu
    {
        private int optionSelected;
        private FileProcesses fileProcesses = new FileProcesses();
        public void menu()
        {
            do{
                Console.WriteLine("---------Generador de Listas de Tareas---------");

                //Console.WriteLine("\n");
                Console.WriteLine("         1. Crear Lista de Tareas");
                Console.WriteLine("         2. Ver Lista de Tareas");
                Console.WriteLine("         3. Eliminar Lista de Tareas");
                Console.WriteLine("         0. Salir");
                Console.WriteLine("\n");
                Console.Write("Escoja una opcion: ");
                optionSelected = Convert.ToInt32(Console.ReadLine());


                switch (optionSelected)
                {
                    case 1:
                        fileProcesses.createToDoList();
                        break;
                    case 2:
                        fileProcesses.seeToDoList();
                        break;
                    case 3:
                        fileProcesses.deleteToDoList();
                        break;
                    default:
                        break;
                }

                Console.Clear();
            } while (optionSelected != 0);


        }
            
    }
}
