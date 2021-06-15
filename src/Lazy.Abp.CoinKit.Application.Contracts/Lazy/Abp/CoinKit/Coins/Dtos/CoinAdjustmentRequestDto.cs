using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    public class CoinAdjustmentRequestDto
    {
        public int Amount { get; set; } 

        public string Reason { get; set; }
    }
}
