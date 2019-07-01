using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class FisherPlayer
    {
        /// <summary>Fish/IsKO</summary>
        public List<KeyValuePair<Fish, bool>> Fish = new List<KeyValuePair<Fish, bool>>();

        public string Name { get; }

        public FisherPlayer(string name)
        {
            this.Name = name;
        }

        public void AddFish(Fish fish)
        {
            this.Fish.Add(new KeyValuePair<Fish, bool>(fish, false));
        }

    }
}
