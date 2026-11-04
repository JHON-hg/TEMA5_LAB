using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        int opcion = 0;
        do{
            Console.WriteLine("=== GESTION DE CONTACTOS ===");
            Console.WriteLine("1. Registrar contacto");
            Console.WriteLine("2. Mostrar contactos");
            Console.WriteLine("3. Buscar contacto por ID");
            Console.WriteLine("4. Contar contactos");
            Console.WriteLine("5. Crear ejemplo de archivo binario");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opcion:");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion){
                case 1:RegistrarContacto();break;
                case 2:MostrarContactos();break;
                case 3:BuscarContacto();break;
                case 4:ContarContactos();break;
                case 5:CrearArchivoBinario();break;
                case 0:Console.WriteLine("programa finalizado...");break;
                default:Console.WriteLine("opcion no valida...");break;
            }
        } while (opcion != 0);
    }
    // ============================================================================================
    // ============================================================================================
    static void RegistrarContacto()
    {
        Console.Write("ID: ");
        string id = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Telefono: ");
        string telefono = Console.ReadLine();

        string registro = id + "," + nombre + "," + telefono;
        using (var archivo = new StreamWriter("contactos.txt", true, Encoding.UTF8))
        {
            archivo.WriteLine(registro);
        }
        Console.WriteLine("contacto guardado...");
    }
}