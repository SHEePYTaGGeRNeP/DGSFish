﻿using System.Collections;
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
        private uint _baseDamage;
        public uint BaseDamage => this._baseDamage;

        [SerializeField]
        private uint _damageDie;
        public uint DamageDie => this._damageDie;

        [SerializeField]
        private uint _amountOfDamageDie;
        public uint AmountOfDamageDie => this._amountOfDamageDie;

        [SerializeField]
        private string _attackName;
        public string AttackName => this._attackName;

        [SerializeField]
        private uint _catchDie;
        public uint CatchDie => this._catchDie;

        [SerializeField]
        private uint[] _catchValues;
        public uint[] CatchValues => this._catchValues;

        public bool WouldCatch(uint dieValue) => this.CatchValues.Contains(dieValue);

        public uint RollDamage() => Die.Roll(this.AmountOfDamageDie, this.DamageDie) + this.BaseDamage;

        public override string ToString()
        {
            return $"{this.Name} {this.AmountOfDamageDie}d{this.DamageDie}+{this.BaseDamage}";
        }

    }
}