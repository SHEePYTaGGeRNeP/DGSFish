using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.Game.Cards
{
    [CreateAssetMenu(fileName = "DamageCard", menuName = "Cards/CreateDamageCard", order = 0)]
    public class DamageCard : Card
    {
        [SerializeField]
        private int _damage;

        public override bool CanPlay() => true;

        public override void Play()
        {
            // TODO
        }
    }
}
