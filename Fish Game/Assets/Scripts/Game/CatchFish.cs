using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Game;

public class CatchFish : MonoBehaviour
{
    public FishHolder fishHolder;

    private GameObject DefaultScreen;
    private GameObject FightEvent;
    private GameObject CatchFishEvent;

    private Fish fishToCatch;
    private uint rollNumber;

    private void Awake()
    {
        DefaultScreen = GameObject.Find("Canvas");
        FightEvent = GameObject.Find("FightCanvas");
        CatchFishEvent = GameObject.Find("CatchFishCanvas");

        CatchFishEvent.SetActive(false);
        FightEvent.SetActive(false);
    }
    public void StartCatchEvent()
    {
        DefaultScreen.SetActive(false);
        FightEvent.SetActive(false);
        CatchFishEvent.SetActive(true);

        SetupFish();
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
        GameSystem.Instance.NextPlayer();
        DefaultScreen.SetActive(true);
        CatchFishEvent.SetActive(false);
    }
}
