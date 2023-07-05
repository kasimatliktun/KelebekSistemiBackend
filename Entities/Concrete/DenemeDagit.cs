using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DenemeDagit : IEntity
    {
        public int Id { get; set; }
        public string Sinif { get; set; }
        public byte SiraNo { get; set; }
        public int DagitNo { get; set; }        
        public string DagitAdi { get; set; }
        public string Salon { get; set; }
        public int OgrenciNo { get; set; }
        public string OgrenciAdi { get; set; }
        public byte YerNo { get; set; }        
    }
}
