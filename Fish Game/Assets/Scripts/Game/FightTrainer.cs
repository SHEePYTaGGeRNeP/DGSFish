using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Cards;
using UnityEngine;
using UnityEngine.UI;

public class FightTrainer : MonoBehaviour
{
    [SerializeField]
    private List<Trainer> _trainers = new List<Trainer>();
    public Trainer Opponent { get; private set; }
    public Dropdown _cardsDropdown;

    [SerializeField]
    private MenuHandler _menuHandler;
    [SerializeField]
    private FishInfoCard _playerFishInfoCard;
    [SerializeField]
    private FishInfoCard _opponentFishInfoCard;
    [SerializeField]
    private Text _rolledText;
    [SerializeField]
    private Text _playerFishText;
    [SerializeField]
    private Text _opponentFishText;

    [SerializeField]
    private GameObject updateCardList;

    private uint _playerRoll;

    public void NewOpponent()
    {
        this.Opponent = this.ChooseRandomTrainer();
        ConsoleLog.AddToLog($"You're fighting {this.Opponent.name}'s {this.Opponent.fish.name} with your {GameSystem.Instance.CurrentPlayer.SelectedFish.Name}.");
        this._playerRoll = this.RollPlayer();
        this._rolledText.text = this._playerRoll.ToString();
        this._playerFishInfoCard.ShowFish(GameSystem.Instance.CurrentPlayer.SelectedFish, false);
        this._playerFishText.text = $"{GameSystem.Instance.CurrentPlayer.Name}'s fish";
        this._opponentFishInfoCard.ShowFish(this.Opponent.fish, true);
        this._opponentFishText.text = $"{this.Opponent.name}'s fish";
        Debug.Log("State " + GameSystem.Instance.CurrentState);
        //this.updateCardList.GetComponent<UpdateCardList>().updateList();
    }

    public void SelectedFishChanged(int index)
    {
        this._playerFishInfoCard.ShowFish(GameSystem.Instance.CurrentPlayer.SelectedFish, false);
        this._playerRoll = this.RollPlayer();
        this._rolledText.text = this._playerRoll.ToString();
    }

    public void ResolveClick()
    {
        List<DamageCard> cards = new List<DamageCard>();
        if (this._cardsDropdown.value > 0)
        {
            string selectedCard = this._cardsDropdown.options[this._cardsDropdown.value].text;
            DamageCard y = (DamageCard)GameSystem.Instance.CurrentPlayer.Cards.First(x => x.Name == selectedCard);
            cards.Add(y);
        }
        this.ResolveFight(this._playerRoll, cards);
    }

    public void ResolveFight(uint playerDamage, IEnumerable<DamageCard> playedCards)
    {
        Debug.Log("Resolving");
        foreach (DamageCard card in playedCards)
            GameSystem.Instance.CurrentPlayer.RemoveCard(card);
        uint extraPlayerDamage = (uint)playedCards.Sum(x => x.Damage);
        uint finalPlayerDamage = playerDamage + extraPlayerDamage;
        uint opponentDamage = this.Opponent.fish.RollDamage();
        ConsoleLog.AddToLog($"{this.Opponent.fish.name} uses {this.Opponent.fish.AttackName}");
        ConsoleLog.AddToLog($"{this.Opponent.name}'s {this.Opponent.fish.name} has rolled a total of {opponentDamage}.");
        ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer} uses {GameSystem.Instance.CurrentPlayer.SelectedFish.AttackName}");
        ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer}'s {GameSystem.Instance.CurrentPlayer.SelectedFish.name} has an attack of {finalPlayerDamage}.");
        if (opponentDamage > finalPlayerDamage)
        {
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer}'s {GameSystem.Instance.CurrentPlayer.SelectedFish.name} has been KO'd.");
            GameSystem.Instance.CurrentPlayer.LostFight();
        }
        else
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer.Name} has won the game!");

        Debug.Log("BACK2MENU");
        this._menuHandler.BackToMenu();
        GameSystem.Instance.NextPlayer();
    }

    private uint RollPlayer() => GameSystem.Instance.CurrentPlayer.SelectedFish.RollDamage();

    private Trainer ChooseRandomTrainer() => this._trainers[Random.Range(0, this._trainers.Count)];
}

