using UnityEngine;

namespace Assets.Scripts.Game
{
    [CreateAssetMenu(fileName = "FishHolder", menuName = "Fish/CreateFishHolder", order = 10)]
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

        [SerializeField]
        private int[] _chancePerType;

        public Fish RandomFish()
        {
            Fish[] type = this._commonFish;
            float value = Random.Range(0, 101);
            int extraAdd = 0;
            int index = 0;
            for (index = 0; index < _chancePerType.Length; index++)
            {
                if (value < _chancePerType[index] + extraAdd)
                {
                    type = IndexToType(index);
                    break;
                }
                extraAdd += _chancePerType[index];
            }
            Fish f = type[Random.Range(0, type.Length)];
            Debug.Log($"Random fish from set: {index} {f}");
            return f;
        }
        private Fish[] IndexToType(int index)
        {
            switch (index)
            {
                default: return this._commonFish;
                case 1: return this._uncommonFish;
                case 2: return this._rareFish;
                case 3: return this._veryRareFish;
                case 4: return this._legendaryFish;
            }
        }
    }
}
