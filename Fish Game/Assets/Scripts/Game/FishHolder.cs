using UnityEngine;

namespace Assets.Scripts.Game
{
    [CreateAssetMenu(fileName = "Fish", menuName = "Fish/CreateFishHolder", order = 10)]
    public class FishHolder : ScriptableObject
    {
        [SerializeField]
        private Fish[] _commonFish;
        [SerializeField]
        private Fish[] _uncommonFish;
        [SerializeField]
        private Fish[] _rareFish;
        [SerializeField]
        private Fish[] _veryRareFish;
        [SerializeField]
        private Fish[] _legendaryFish;

        public Fish RandomFish()
        {
            Fish[] type = this._commonFish;
            return type[Random.Range(0, type.Length)];
        }
    }
}
