using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sourav.Utilities.Scripts.Algoritms.Randomization
{
    public class RandomFairCoinToss
    {
        public static CoinTossResult TossACoin()
        {
            CoinTossResult result = CoinTossResult.Heads;

            float random = Random.Range(0, 1);
            if(random >= 0.5)
            {
                result = CoinTossResult.Heads;
            }
            else
            {
                result = CoinTossResult.Tails;
            }

            return result;
        }
    }

    public enum CoinTossResult : int
    {
        Heads = 0,
        Tails = 1
    }
}
