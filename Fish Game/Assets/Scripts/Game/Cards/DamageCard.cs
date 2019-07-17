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
        private uint _damage;
        public uint Damage => this._damage;

        public override string Description => $"For battling fish. Bonus ({this._damage}).";

        public override bool CanPlay() => GameSystem.Instance.CurrentState == GameSystem.GameState.Battling;

        public override void Play()
        {
            // TODO
            
        }
    }
}
