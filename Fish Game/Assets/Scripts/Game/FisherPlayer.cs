using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class FisherPlayer : MonoBehaviour
    {
        /// <summary>Fish/IsKO</summary>
        public List<KeyValuePair<Fish, bool>> Fish = new List<KeyValuePair<Fish, bool>>();


        public void AddFish(Fish fish)
        {
            this.Fish.Add(new KeyValuePair<Fish, bool>(fish, false));
        }

    }
}
