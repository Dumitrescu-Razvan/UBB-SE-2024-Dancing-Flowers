using System;
using System.Security.Cryptography;
using System.Text;

namespace App.Domain
{
    public class Contract
    {
        public Guid guid { get; }
        private List<Client> clients { get; set; } = new List<Client>();

        private Song song { get; set; } = new Song();
        Contract(Guid guid)
        {
            this.guid = guid;
        }
    }
}
