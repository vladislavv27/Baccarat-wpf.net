using System;
using System.Collections.Generic;

namespace Baccarat
{
    public partial class Score
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Bankerwins { get; set; }
        public int Playerwins { get; set; }
        public int Tiewins { get; set; }
        public int TotalGames { get; set; }
        public int TotalWinMoney { get; set; }
        public int TotalbetedMoney { get; set; }
        public DateTime DateTime { get; set; }
    }
}
