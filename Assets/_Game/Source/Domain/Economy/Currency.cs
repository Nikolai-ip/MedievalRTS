using System;
using UnityEngine;

namespace _Game.Source.Domain
{
    [Serializable]
    public struct Currency
    {
        [field: SerializeField] public int Coins { get; set; }
        [field: SerializeField] public int Wood { get; set; }
        [field: SerializeField] public int Bread { get; set; }
        
        public static Currency operator +(Currency x, Currency y)
        {
            return new Currency { Coins = x.Coins + y.Coins };
        }
    }
}