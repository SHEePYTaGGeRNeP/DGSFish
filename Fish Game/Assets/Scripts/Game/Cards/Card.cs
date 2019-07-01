using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.Game.Cards
{
    public abstract class Card : ScriptableObject, ICard
    {
        [SerializeField]
        private string _name;
        public string Name => this._name;

        public abstract string Description { get; }
        public abstract bool CanPlay();

        public abstract void Play();
    }
}
