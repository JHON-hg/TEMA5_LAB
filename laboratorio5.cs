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
                case 5:ArchivoBinario();break;
                case 0:Console.WriteLine("programa finalizado...");break;
                default:Console.WriteLine("opcion no valida...");break;
            }
        } while (opcion != 0);
    }
// =================================================================================
// =================================================================================
    static void RegistrarContacto()
    {
        Console.Write("ID: ");
        string id = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Telefono: ");
        string telefono = Console.ReadLine();

        string registro = id + "," + nombre + "," + telefono;
        using (var archivo = new StreamWriter("contactos_fund.txt", true, Encoding.UTF8))
        {
            archivo.WriteLine(registro);
        }
        Console.WriteLine("contacto guardado...");
    }
    // =================================================================================
    // =================================================================================
    static void MostrarContactos()
    {
        if (File.Exists("contactos_fund.txt")){
            using (var archivo = new StreamReader("contactos_fund.txt", Encoding.UTF8))
            {
                string linea = archivo.ReadLine();

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("| ID   | Nombre      | Teléfono   |");
                Console.WriteLine("-----------------------------------");
                while (linea != null){
                    string[] datos = linea.Split(',');
                    if (datos.Length == 3){
                        Console.WriteLine($"| {datos[0]}    | {datos[1]}       | {datos[2]} |");
                        Console.WriteLine("-----------------------------------");
                    }
                    linea = archivo.ReadLine();
                }
            }
        }
        else{
            Console.WriteLine("Contacto no encontrado...");
        }

    }
    // ================================================================================
    // ================================================================================
    static void BuscarContacto()
    {
        Console.Write("Escribe el ID que quieres buscar: ");
        string idBuscado = Console.ReadLine();
        bool encontrado = false;

        if (File.Exists("contactos_fund.txt")){
            using (var archivo = new StreamReader("contactos_fund.txt", Encoding.UTF8))
            {
                string linea = archivo.ReadLine();
                while (linea != null)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length == 3 && datos[0] == idBuscado){
                        Console.WriteLine($"Encontrado: {datos[1]} - {datos[2]}");
                        encontrado = true;
                    }
                    linea = archivo.ReadLine();
                }
            }
        }

        if (encontrado == false){
            Console.WriteLine("No existe ID...");
        }
    }
// ================================================================================
// ================================================================================

    static void ContarContactos()
    {
        int cantidad = 0;

        if (File.Exists("contactos_fund.txt")){
            using (var archivo = new StreamReader("contactos_fund.txt", Encoding.UTF8))
            {
                string linea = archivo.ReadLine();
                while (linea != null){
                    string[] datos = linea.Split(',');
                    if (datos.Length == 3){
                        cantidad = cantidad + 1;
                    }
                    linea = archivo.ReadLine();
                }
            }
        }
        Console.WriteLine($"Cantidad de contactos: {cantidad}");
    }
// ================================================================================
// ================================================================================
static void ArchivoBinario()
    {
        Console.WriteLine("Muy complicado, no se como implementar mis ideas... ");
    }
}