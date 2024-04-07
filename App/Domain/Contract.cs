using System;
using System.Security.Cryptography;
using System.Text;

namespace app.Domain
{
   public class Contract
    {
       public Guid guid { get; }

        Contract(Guid guid)
        {
            this.guid = guid;
        }
    }
}
