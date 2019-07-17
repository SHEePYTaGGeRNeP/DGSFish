using UnityEngine;
using System.Linq;

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
            int index;
            for (index = 0; index < this._chancePerType.Length; index++)
            {
                if (value < this._chancePerType[index] + extraAdd)
                {
                    type = this.RarityIndexToFishArray(index);
                    break;
                }
                extraAdd += this._chancePerType[index];
            }
            Fish f = type[Random.Range(0, type.Length)];
            Debug.Log($"Random fish from set: {this.IndexToRarityName(index)} {f}");
            return f;
        }

        private Fish[] RarityIndexToFishArray(int index)
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

        private string IndexToRarityName(int index)
        {
            switch (index)
            {
                default: return "Common";
                case 1: return "Uncommon";
                case 2: return "Rare";
                case 3: return "Elite";
                case 4: return "Legendary";
            }
        }

        public int GetFishRarityIndex(Fish fish)
        {
            if (this._commonFish.Contains(fish))
                return 0;
            if (this._uncommonFish.Contains(fish))
                return 1;
            if (this._rareFish.Contains(fish))
                return 2;
            if (this._veryRareFish.Contains(fish))
                return 3;
            if (this._legendaryFish.Contains(fish))
                return 4;

            throw new System.ApplicationException($"Fish {fish.Name} not found in FishHolder");
        }
    }
}
