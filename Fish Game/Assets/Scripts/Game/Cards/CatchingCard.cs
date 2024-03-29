﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.Game.Cards
{
    [CreateAssetMenu(fileName = "CatchingCard", menuName = "Cards/CreateCatchingCard", order = 0)]
    public class CatchingCard : Card
    {
        [SerializeField]
        private int[] _rollBonus;
        public int[] RollBonus => this. _rollBonus;

        public override string Description => $"For catching fish. Bonusses ({String.Join(", ", this._rollBonus)}.";

        public override bool CanPlay() => GameSystem.Instance.CurrentState == GameSystem.GameState.Catching;

        public override void Play()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
