using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class TestRandomFish : MonoBehaviour
    {
        [SerializeField]
        private FishHolder _fishHolder;

        public void Test()
        {
            this._fishHolder.RandomFish();
        }
    }
}
