using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class FishInfoCard : MonoBehaviour
    {
        [SerializeField]
        private FishHolder _fishHolder;

        [SerializeField]
        private Image _fishImage;
        [SerializeField]
        private Text _fishName;
        [SerializeField]
        private Text _fishCatchInfo;
        [SerializeField]
        private Text _fishAttackName;
        [SerializeField]
        private Text _fishBaseDamage;
        [SerializeField]
        private Text _fishDamageDie;

        public void ShowFish(Fish fish, bool isTrainer)
        {
            Debug.Log($"Updating {this.name} with {fish.Name} info.");
            this._fishImage.sprite = fish.Image;
            this._fishName.text = fish.Name;
            this._fishName.color = isTrainer ? new Color(1,0,0) : ConvertRarityToColor(this._fishHolder.GetFishRarityIndex(fish));
            this._fishBaseDamage.text = fish.BaseDamage.ToString();
            this._fishDamageDie.text = fish.AmountOfDamageDie + "d" + fish.DamageDie;
            this._fishAttackName.text = fish.AttackName;
            this._fishCatchInfo.text = fish.CatchValues.Length == 0 ? String.Empty : String.Join("/", fish.CatchValues);
        }

        private static Color ConvertRarityToColor(int grade)
        {
            switch (grade)
            {
                case 0:
                    return new Color(0, 0, 0, 1);
                case 1:
                    return new Color(0, 1, 0, 1);
                case 2:
                    return new Color(1, 0.2f, 0.2f, 1);
                case 3:
                    return new Color(0.6f, 0, 0.8f, 1);
                case 4:
                    return new Color(1, 1, 0, 1);
                default:
                    return new Color(0, 0, 0, 1);
            }
        }

    }
}
