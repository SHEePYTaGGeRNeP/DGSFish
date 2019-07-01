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
        card.transform.GetChild(2).GetComponent<Image>().color = ConvertGradeToColor(fishHolder.GradeToInt(fishToCatch));
        card.transform.GetChild(3).GetComponent<Text>().text = fishToCatch.BaseDamage.ToString();
        card.transform.GetChild(4).GetComponent<Text>().text = fishToCatch.AmountOfDamageDie + "d" + fishToCatch.DamageDie;
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
            Debug.Log("<color=blue>You caught " + fishToCatch.Name + "!</color>");
            GameSystem.Instance.CurrentPlayer.AddFish(fishToCatch);
            EndCatchEvent();
        }
        else
        {
            Debug.Log("<color=maroon>Despite your best efforts " + fishToCatch.Name + " got away!</color>");
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
