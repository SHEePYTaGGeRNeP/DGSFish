using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Game;
using System.Linq;
using Assets.Scripts.Game.Cards;

public class CatchFish : MonoBehaviour
{
    public FishHolder fishHolder;

    private GameObject DefaultScreen;
    private GameObject CatchFishEvent;
    private Dropdown dropdownCards;

    private Fish fishToCatch;
    private uint rollNumber;

    private void Awake()
    {
        DefaultScreen = GameObject.Find("Canvas");
        CatchFishEvent = GameObject.Find("CatchFishCanvas");
        dropdownCards = GameObject.Find("Dropdown").GetComponent<Dropdown>();

        CatchFishEvent.SetActive(false);
    }
    public void StartCatchEvent()
    {
        DefaultScreen.SetActive(false);
        CatchFishEvent.SetActive(true);

        SetupFish();
        SetupCards();
    }
    private void SetupFish()
    {
        fishToCatch = fishHolder.RandomFish();
        rollNumber = Die.Roll(fishToCatch.CatchDie);
        GameObject card = GameObject.Find("FishCard");
        card.transform.GetChild(0).GetComponent<Image>().sprite = fishToCatch.Image;
        card.transform.GetChild(1).GetComponent<Text>().text = fishToCatch.Name;
        card.transform.GetChild(2).GetComponent<Image>().color = ConvertGradeToColor(fishHolder.GradeToInt(fishToCatch));
        card.transform.GetChild(3).GetComponent<Text>().text = fishToCatch.BaseDamage.ToString();
        card.transform.GetChild(4).GetComponent<Text>().text = fishToCatch.AmountOfDamageDie + "d" + fishToCatch.DamageDie;
        card.transform.GetChild(5).GetComponent<Text>().text = "Thrown: " + rollNumber + ", Needed: ";

        for (int i = 0; i < fishToCatch.CatchValues.Length; i++)
        {
            card.transform.GetChild(5).GetComponent<Text>().text += fishToCatch.CatchValues[i] + "/";
        }
    }
    private void SetupCards()
    {
        dropdownCards.ClearOptions();
        dropdownCards.options.Add(new Dropdown.OptionData("NONE"));
        foreach (Card c in GameSystem.Instance.CurrentPlayer.PlayableCards)
        {
            dropdownCards.options.Add(new Dropdown.OptionData(c.Name));
        }
    }
    private Color ConvertGradeToColor(uint grade)
    {
        switch (grade)
        {
            case 0:
                return new Color(0, 0, 0, 0);
            case 1:
                return new Color(0, 1, 0, 1);
            case 2:
                return new Color(1, 0.2f, 0.2f, 1);
            case 3:
                return new Color(0.6f, 0, 0.8f, 1);
            case 4:
                return new Color(1, 1, 0, 1);
            default:
                return new Color(0, 0, 0, 0);
        }
    }
    public void TryCatchFish()
    {
        if (fishToCatch.CatchSuccess(rollNumber))
        {
            ConsoleLog.AddToLog($"<color=blue>{GameSystem.Instance.CurrentPlayer.Name} caught a " + fishToCatch.Name + "!</color>");
            GameSystem.Instance.CurrentPlayer.AddFish(fishToCatch);
            EndCatchEvent();
        }
        else
        {
            ConsoleLog.AddToLog("<color=maroon>Despite your best efforts " + fishToCatch.Name + " got away!</color>");
            EndCatchEvent();
        }
    }
    public void ReleaseFish()
    {
        EndCatchEvent();
    }
    private void EndCatchEvent()
    {
        ICard thisCard = GameSystem.Instance.CurrentPlayer.Cards.FirstOrDefault(x => x.Name == dropdownCards.captionText.text);

        if (null != thisCard)
        {
            GameSystem.Instance.CurrentPlayer.RemoveCard(thisCard);
        }

        GameSystem.Instance.NextPlayer();
        DefaultScreen.SetActive(true);
        CatchFishEvent.SetActive(false);
    }
    public void PickACard()
    {
        //update roll number to be better based on picked card

    }
}
