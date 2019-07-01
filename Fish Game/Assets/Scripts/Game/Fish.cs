using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [CreateAssetMenu(fileName = "Fish", menuName = "Fish/CreateFish", order = 0)]
    public class Fish : ScriptableObject
    {
        [SerializeField]
        private string _name;
        public string Name => this._name;

        [SerializeField]
        private Sprite _image;
        public Sprite Image => this._image;

        public bool IsKO { get; set; }

        [SerializeField]
        private int _baseDamage;
        public int BaseDamage => this._baseDamage;

        [SerializeField]
        private Die _damageDie;
        public Die DamageDie => this._damageDie;

        [SerializeField]
        private uint _amountOfDamageDie;
        public uint AmountOfDamageDie => this._amountOfDamageDie;

        [SerializeField]
        private Die _catchDie;
        public Die CatchDie => this._catchDie;

        [SerializeField]
        private int[] _catchValues;
        public int[] CatchValues => this._catchValues;
    }
}