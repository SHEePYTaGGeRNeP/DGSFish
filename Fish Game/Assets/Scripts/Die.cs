using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Die
    {
        public static readonly Die D4 = new Die(4);
        public static readonly Die D6 = new Die(6);
        public static readonly Die D8 = new Die(8);
        public static readonly Die D10 = new Die(10);
        public static readonly Die D12 = new Die(12);
        public static readonly Die D20 = new Die(20);
        public static readonly Die D100 = new Die(100);

        [SerializeField]
        private uint _nrOfSides;
        public uint NrOfSides
        {
            get => this._nrOfSides;
            set => this._nrOfSides = value;
        }

        public Die(uint nrOfSides)
        {
            this.NrOfSides = nrOfSides;
        }


        public static uint Roll(IEnumerable<KeyValuePair<Die, uint>> dice)
        {
            uint total = 0;
            foreach (KeyValuePair<Die, uint> die in dice)
            {
                total += Roll(die.Value, die.Key.NrOfSides);
            }
            return total;
        }

        public uint Roll() => Roll(1, this.NrOfSides);
        public static uint Roll(uint nrOfSides) => Roll(1, nrOfSides);
        public static uint Roll(uint nrOfDice, uint nrOfSides)
        {
            uint total = 0;
            for (int i = 0; i < nrOfDice; i++)
                total += (uint)UnityEngine.Random.Range(1, (int)nrOfSides); ;
            return total;
        }

        public override string ToString()
        {
            return $"d{this.NrOfSides}";
        }

    }
}
