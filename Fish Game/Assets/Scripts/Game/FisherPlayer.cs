using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class FisherPlayer : MonoBehaviour
    {
        /// <summary>Fish/IsKO</summary>
        public Dictionary<Fish, bool> Fish = new Dictionary<Fish, bool>();


        public void AddFish(Fish fish)
        {
            this.Fish.Add(fish, false);
        }


    }
}
