using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
