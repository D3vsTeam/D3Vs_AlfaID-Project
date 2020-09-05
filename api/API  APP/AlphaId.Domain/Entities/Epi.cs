using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaId.Domain.Entities
{
    public class Epi : BaseEntity
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string ApproveCertificate { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public long Durability { get; set; }

        public EpiType EpiType { get; set; }

        public bool ValidateName()
        {
            if (Name.Length < 3 || Name.Length > 100)
                return false;

            return true;
        }

        public bool ValidateQuantity()
        {
            if (Quantity <= 0)
                return false;

            return true;
        }

        public bool CheckExpiration()
        {
            var expiration = Expiration();

            if (expiration <= 0)
                return false;
            else
                return true;
        }

        public long Expiration()
        {
            var currentDate = DateTime.Now;
            var dueDate = ManufacturingDate.AddHours(Durability);
            var expiration = dueDate.Subtract(currentDate).TotalHours;

            return (long)expiration;
        }
    }
}
