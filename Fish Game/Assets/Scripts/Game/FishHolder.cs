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
            int index;
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
            Debug.Log($"Random fish from set: {IndexToName(index)} {f}");
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
        private string IndexToName(int index)
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
        public uint GradeToInt(Fish fish)
        {
            uint grade = 0;

            for (int i = 0; i < _commonFish.Length; i++)
            {
                if (_commonFish[i] == fish)
                {
                    grade = 0;
                }
            }

            for (int i = 0; i < _uncommonFish.Length; i++)
            {
                if (_uncommonFish[i] == fish)
                {
                    grade = 1;
                }
            }

            for (int i = 0; i < _rareFish.Length; i++)
            {
                if (_rareFish[i] == fish)
                {
                    grade = 2;
                }
            }

            for (int i = 0; i < _veryRareFish.Length; i++)
            {
                if (_veryRareFish[i] == fish)
                {
                    grade = 3;
                }
            }

            for (int i = 0; i < _legendaryFish.Length; i++)
            {
                if (_legendaryFish[i] == fish)
                {
                    grade = 4;
                }
            }

            return grade;
        }
    }
}
