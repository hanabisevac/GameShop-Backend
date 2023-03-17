using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string? GameName { get; set; } = null;
        public string? Description { get; set; } = null;
        public int TypeId { get; set; }
        public Type? Type  { get; set; } = null;

    }
}
