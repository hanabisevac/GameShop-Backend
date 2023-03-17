using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Entities
{
    public class PurchaseHistory
    {
        public int PurchaseHistoryId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } = null;
        public int GameId { get; set; }
        public Game? Game { get; set; } = null;
        public string? GameName { get; set; } = null;
        public decimal Price { get; set; }
        public DateTime? PurchaseDate { get; set; } = null;
    }
}
