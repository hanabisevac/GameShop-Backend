using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Entities
{
    public class GameConsole
    {
        public int GameConsoleId { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; } = null;
        public int ConsoleId { get; set; }
        public Console? Console { get; set; } = null;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
