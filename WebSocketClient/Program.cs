﻿using System;
using WebSocketSharp;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket ("ws://127.0.0.1:8001/quiz?name=poppetje&room=123")) {
                ws.OnMessage += (sender, e) =>
                    Console.WriteLine (e.Data);
                ws.OnError += (sender, eventArgs) =>
                    ws.Close();

                ws.Connect();
                ws.Send("{\"Type\":\"IsReady\",\"test\":\"test\"}");
                while (true)
                {
                    ws.Send(Console.ReadLine());
                }
            }
        }
    }
}