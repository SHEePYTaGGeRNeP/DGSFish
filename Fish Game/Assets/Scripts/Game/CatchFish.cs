using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Cards;
using UnityEngine;
using UnityEngine.UI;

public class CatchFish : MonoBehaviour
{
    public FishHolder fishHolder;

    [SerializeField]
    private GameObject _defaultScreen;
    [SerializeField]
    private GameObject _catchFishCanvas;
    [SerializeField]
    private Dropdown dropdownCards;
    [SerializeField]
    private FishInfoCard _fishInfoCard;
    [SerializeField]
    private Text _rolledText;

    private Fish fishToCatch;
    private uint rollNumber;

    private void Awake()
    {
        this._catchFishCanvas.SetActive(false);
    }
    public void StartCatchEvent()
    {
        this._defaultScreen.SetActive(false);
        this._catchFishCanvas.SetActive(true);

        this.SetupFish();
        this.SetupCards();
    }
    private void SetupFish()
    {
        this.fishToCatch = this.fishHolder.RandomFish();
        this.rollNumber = Die.Roll(this.fishToCatch.CatchDie);
        this._fishInfoCard.ShowFish(this.fishToCatch, false);
        this._rolledText.text = this.rollNumber.ToString();
        this._rolledText.color = this.GetRolledTextColor();
    }
    private void SetupCards()
    {
        this.dropdownCards.ClearOptions();
        this.dropdownCards.options.Add(new Dropdown.OptionData("NONE"));
        foreach (Card c in GameSystem.Instance.CurrentPlayer.PlayableCards)
        {
            this.dropdownCards.options.Add(new Dropdown.OptionData(c.Name));
        }
    }

    private Color GetRolledTextColor()
    {
        if (this.fishToCatch.WouldCatch(this.rollNumber))
            return Color.green;

        foreach (Card c in GameSystem.Instance.CurrentPlayer.PlayableCards)
        {
            if (!(c is CatchingCard cc))
                continue;
            foreach (int bonus in cc.RollBonus)
                if (this.fishToCatch.WouldCatch(this.rollNumber + (uint)bonus))
                    return new Color(1, 1, 0);
        }
        return Color.red;
    }

    public void TryCatchFish()
    {
        this.EndCatchEvent();
    }

    private void EndCatchEvent()
    {
        ICard playedCard = GameSystem.Instance.CurrentPlayer.Cards.FirstOrDefault(x => x.Name == this.dropdownCards.captionText.text);
        uint finalRoll = this.rollNumber;
        if (null != playedCard)
        {
            ConsoleLog.AddToLog($"Removed card {playedCard.Name}");
            GameSystem.Instance.CurrentPlayer.RemoveCard(playedCard);
            if (playedCard is CatchingCard cc)
            {
                foreach (int bonus in cc.RollBonus)
                    if (this.fishToCatch.WouldCatch(this.rollNumber + (uint)bonus))
                    {
                        finalRoll = this.rollNumber + (uint)bonus;
                        break;
                    }
            }
        }

        if (this.fishToCatch.WouldCatch(finalRoll))
        {
            ConsoleLog.AddToLog($"<color=blue>{GameSystem.Instance.CurrentPlayer.Name} caught a " + this.fishToCatch.Name + "!</color>");
            GameSystem.Instance.CurrentPlayer.AddFish(this.fishToCatch);
        }
        else
        {
            ConsoleLog.AddToLog("<color=maroon>Despite your best efforts " + this.fishToCatch.Name + " got away!</color>");
        }
        GameSystem.Instance.NextPlayer();
        this._defaultScreen.SetActive(true);
        this._catchFishCanvas.SetActive(false);
    }


}
