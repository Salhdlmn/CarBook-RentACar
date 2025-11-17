using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Customer

    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string Email { get; set; }

        public List<RentACar> RentACars { get; set; }

        public List<RentACarProcess> RentACarProcesses { get; set; }
    }
}
