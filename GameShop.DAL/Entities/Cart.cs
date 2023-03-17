using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } = null;
        public int GameId { get; set; }
        public Game? Game { get; set; } = null;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
