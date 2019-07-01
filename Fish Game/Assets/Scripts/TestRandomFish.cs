using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class TestRandomFish : MonoBehaviour
    {
        [SerializeField]
        private FishHolder _fishHolder;

        [SerializeField]
        private ConsoleLog _log;
        public void Test()
        {
            this._fishHolder.RandomFish();
            this._log.AddToLog("Hello " + Time.time);
        }
    }
}
