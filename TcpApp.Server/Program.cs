using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Server
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener server = new TcpListener(5555);
            server.Start();

            Console.WriteLine("server başlatıldı..");

            TcpClient getClients = server.AcceptTcpClient();

            NetworkStream ns = getClients.GetStream();

            //byte[] gonderilmisDeger =Encoding.UTF8.GetBytes()
            byte[] deger = new byte[getClients.ReceiveBufferSize];

            ns.Read(deger, 0, deger.Length);

            Console.WriteLine("Gelen Mesaj :" + Encoding.UTF8.GetString(deger));

            string donulecekDeger = "mesajınız alındı..";

            byte[] gonderilecekDeger = Encoding.UTF8.GetBytes(donulecekDeger);
            ns.Write(gonderilecekDeger, 0, gonderilecekDeger.Length);



        }
    }
}
