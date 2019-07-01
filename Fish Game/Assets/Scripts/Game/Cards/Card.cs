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
        public abstract bool CanPlay();

        public abstract void Play();
    }
}
