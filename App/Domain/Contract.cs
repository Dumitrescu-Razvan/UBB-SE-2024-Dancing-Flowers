using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace App.Domain
{
    public class Contract
    {
        public int id { get; }
        public int client1 { get; set; }
        public int client2 { get; set; }
        public int song { get; set; }

        public Contract(int id)
        {
            this.id = id;

            client1 = -1;
            client2 = -1;
            song = -1;
        }

        public Contract(int id,int client1, int client2, int song)
        {
            //Constructor with all the attributes
            this.id = id;
            this.client1 = client1;
            this.client2 = client2;
            this.song = song;
        }

        

    }
}
