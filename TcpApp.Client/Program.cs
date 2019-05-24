using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 5555);

            Console.WriteLine("Client Başlatıldı");
            NetworkStream ns = client.GetStream();

            Console.WriteLine("mesaj giriniz.. ");
            string gonderilecekClientMesajı = Console.ReadLine();

            byte[] writeBytes = Encoding.UTF8.GetBytes(gonderilecekClientMesajı);

            ns.Write(writeBytes, 0, writeBytes.Length);

            byte[] gelenServerMesaji = new byte[client.ReceiveBufferSize];
            ns.Read(gelenServerMesaji, 0, gelenServerMesaji.Length);

            Console.WriteLine("Server:" + Encoding.UTF8.GetString(gelenServerMesaji));

        }
    }
}
