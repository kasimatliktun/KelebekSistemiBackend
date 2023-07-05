using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public User()
        {
            if (Id == 0)
            {
                RecordDate = DateTime.Now;
            }
            UpdateContactDate = DateTime.Now;
            Status = true;
        }

        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }                        
        public int Numara { get; set; }                        
        public int Sinif { get; set; }                        
        public bool Status { get; set; }        
        public DateTime RecordDate { get; set; }        
        public DateTime UpdateContactDate { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

       
    }
}
