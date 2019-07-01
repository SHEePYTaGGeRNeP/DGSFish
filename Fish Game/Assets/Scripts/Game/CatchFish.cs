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
    private GameObject CatchFishEvent;

    private Fish fishToCatch;

    private void Awake()
    {
        DefaultScreen = GameObject.Find("Canvas");
        CatchFishEvent = GameObject.Find("CatchFishCanvas");

        CatchFishEvent.SetActive(false);
    }
    public void StartCatchEvent()
    {
        DefaultScreen.SetActive(false);
        CatchFishEvent.SetActive(true);

        SetupFish();
    }
    private void SetupFish()
    {
        fishToCatch = fishHolder.RandomFish();
        GameObject card = GameObject.Find("FishCard");
        card.transform.GetChild(0).GetComponent<Image>().sprite = fishToCatch.Image;
        card.transform.GetChild(1).GetComponent<Text>().text = fishToCatch.Name;
        card.transform.GetChild(2).GetComponent<Text>().text = "empty";
        card.transform.GetChild(3).GetComponent<Text>().text = fishToCatch.BaseDamage.ToString();
        card.transform.GetChild(4).GetComponent<Text>().text = fishToCatch.AmountOfDamageDie + "d" + fishToCatch.DamageDie;
    }
    public void TryCatchFish()
    {
        uint RollNumber = Die.Roll(fishToCatch.CatchDie);

        Debug.Log("Your roll:" + RollNumber);
        string required = "Required roll: ";
        for (int i = 0; i < fishToCatch.CatchValues.Length; i++)
        {
            required += fishToCatch.CatchValues[i] + "/";
        }
        Debug.Log(required);

        if (fishToCatch.CatchSuccess(RollNumber))
        {
            ConsoleLog.AddToLog($"<color=blue>{GameSystem.Instance.CurrentPlayer.Name} caught a " + fishToCatch.Name + "!</color>");
            Debug.Log($"<color=blue>{GameSystem.Instance.CurrentPlayer.Name} caught a " + fishToCatch.Name + "!</color>");
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
        DefaultScreen.SetActive(true);
        CatchFishEvent.SetActive(false);
    }
}
