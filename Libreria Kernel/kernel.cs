using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Principal;
using System.Resources;
using System.Management;
using System.Xml.Linq;

namespace Libreria_Kernel
{
    internal class kernel
    {
        /// <summary>
        /// Libreria del Kernel
        /// </summary>
        public static void LeerNumSerie()
        {            
            
        }
        public static void CantidadUnidadesDisco()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();//Clase de Discos, donde guarda cada disco en un Array con toda la informacion

            foreach (DriveInfo d in allDrives) //Lee cada disco almacenado en el Array, y por cada disco empieza a mostrar por consola la informacion
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);

                    Console.WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);

                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
                    Console.WriteLine("  Root directory:            {0, 12}", d.RootDirectory);
                }
            }
        }
        public static void BalanceGeneralSistema()
        {
            
        }
        public static ArrayList ObtenerMacAdress()
        {
            //A cada tarjeta de red le asingan una direccion Mac, pero un computador puede tener varias tarjetas de red
            //entonces puede tener varias direcciones Mac, por eso cree la lista
            ArrayList direccionesMAC = new ArrayList(); //Lista para guardar las direcciones
            NetworkInterface[] adaptadoresRed = NetworkInterface.GetAllNetworkInterfaces();//obtener cantidad de adaptadores de Red
            if (adaptadoresRed != null && adaptadoresRed.Length > 0) //verificar si hay uno o mas adaptadores
            {
                foreach(NetworkInterface networkInterface in adaptadoresRed) //recorrer cada adaptador
                {
                    var direccion = networkInterface.GetPhysicalAddress();//obtiene direccion fisica del adaptador actual
                    byte[] bytes = direccion.GetAddressBytes();//guarda direccion en bites del adaptador actual
                    string mac = string.Empty;
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        mac+= bytes[i].ToString("x2");//guarda las direccion del vector en pares
                        if (i != bytes.Length - 1)
                        {
                            mac += "-";//cuando esté en el ultimo valor, le agrega "-" para estetica (que se vea bonito pues)
                        }
                    }
                    direccionesMAC.Add(mac); //empuja las direcciones guardadas en la arrayList
                }
            }
            return direccionesMAC;
        }
        public static void RegEdit()
        {
            
        }
        public static void listaProcesos()
        {
            try
            {
                foreach (Process procesos in Process.GetProcesses())
                {
                    Console.WriteLine(procesos.ProcessName);//Nombre del proceso
                    Console.Write(procesos.Id);//ID del proceso
                    Console.Write(procesos.WorkingSet64);//RAM del proceso
                    Console.Write(procesos.VirtualMemorySize64);//Memoria Virtual del Proceso
                    Console.Write(procesos.SessionId);//CPU que usa el proceso
                }
                //Usa la clase process que es donde se guarda todo acerca de procesos
                string elemento = Console.ReadLine();
                foreach (Process procesos in Process.GetProcesses())//recorre cada proceso activo
                {
                    if (procesos.ProcessName == elemento)//Compara si el proceso actual es el mismo al que se pide
                    {
                        procesos.Kill();//elimina el proceso
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("No existe el elemento o hubo un error en el proceso. " + error.Message);
            }
            
        }
        
    }
    
}
