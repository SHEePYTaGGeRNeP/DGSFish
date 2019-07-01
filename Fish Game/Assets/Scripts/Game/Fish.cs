using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        [SerializeField]
        private int _baseDamage;
        public int BaseDamage => this._baseDamage;

        [SerializeField]
        private int _damageDie;
        public int DamageDie => this._damageDie;

        [SerializeField]
        private uint _amountOfDamageDie;
        public uint AmountOfDamageDie => this._amountOfDamageDie;

        [SerializeField]
        private int _catchDie;
        public int CatchDie => this._catchDie;

        [SerializeField]
        private int[] _catchValues;
        public int[] CatchValues => this._catchValues;

        public bool CatchSuccess(int dieValue) => this.CatchValues.Contains(dieValue);
        
    }
}