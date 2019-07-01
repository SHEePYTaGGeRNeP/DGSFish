using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [CreateAssetMenu(fileName = "Trainer", menuName = "trainer", order = 1)]
    public class Trainer : ScriptableObject
    {
        public new string name;
        public Fish fish;
    }
}