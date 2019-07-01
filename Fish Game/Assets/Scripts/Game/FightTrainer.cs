using System.Collections.Generic;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Cards;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class FightTrainer : MonoBehaviour
{
    [SerializeField]
    private List<Trainer> _trainers = new List<Trainer>();
    public Trainer Opponent { get; private set; }
    public Dropdown _Dropdown;

    [SerializeField]
    private MenuHandler _menuHandler;
    [SerializeField]
    private Text _opponentText;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    private GameObject updateCardList;

    private uint _playerRoll;
    
    public void fightTrainer()
    {
        Opponent = choseRandomTrainer();
        Debug.Log(Opponent.name);
        Debug.Log(Opponent.fish);
        ConsoleLog.AddToLog($"You're fighting {Opponent.name} with a {Opponent.fish.name}.");
        this._playerRoll = rollPlayer();
        this._playerText.text = $"Player: {_playerRoll}";
        this._opponentText.text = $"Opponent: {Opponent.fish.AmountOfDamageDie}d{Opponent.fish.DamageDie}+{Opponent.fish.BaseDamage}";
        Debug.Log("State " + GameSystem.Instance.CurrentState);
        //this.updateCardList.GetComponent<UpdateCardList>().updateList();
    }

    public void resolveClick()
    {
        string name = _Dropdown.options[_Dropdown.value].text;
        List<DamageCard> cards = new List<DamageCard>();
        if (name != "NONE")
        {
            DamageCard y = (DamageCard) GameSystem.Instance.CurrentPlayer.Cards.First(x => x.Name == name);
            if (y) cards.Add(y);
        }

        resolveFight(this._playerRoll, cards );
    }
    
    public void resolveFight(uint playerDamage, IEnumerable<DamageCard> playedCards)
    {
        Debug.Log("Resolving");
        foreach (DamageCard card in playedCards)
            GameSystem.Instance.CurrentPlayer.RemoveCard(card);
        uint extraPlayerDamage = (uint)playedCards.Sum(x => x.Damage);
        uint finalPlayerDamage = playerDamage + extraPlayerDamage;
        uint opponentDamage = Opponent.fish.RollDamage();
        ConsoleLog.AddToLog($"{Opponent.name}'s {Opponent.fish.name} has an attack of {opponentDamage}.");
        ConsoleLog.AddToLog($"{Opponent.fish.name} uses {Opponent.fish.AttackName}");
        ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer}'s {GameSystem.Instance.CurrentPlayer.selectedFish.name} has an attack of {finalPlayerDamage}.");
        ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer} uses {GameSystem.Instance.CurrentPlayer.selectedFish.AttackName}");
        if (opponentDamage > finalPlayerDamage)
        {
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer}'s {GameSystem.Instance.CurrentPlayer.selectedFish.name} has been KO'd.");
            GameSystem.Instance.CurrentPlayer.LostFight();
        }
        else
            ConsoleLog.AddToLog($"{GameSystem.Instance.CurrentPlayer.Name} has won the game!");

        Debug.Log("BACK2mENU");
        this._menuHandler.BackToMenu();
        GameSystem.Instance.NextPlayer();
    }

    private uint rollPlayer()
    {
        return GameSystem.Instance.CurrentPlayer.selectedFish.RollDamage();
    }

    private Trainer choseRandomTrainer()
    {
        return _trainers[Random.Range(0, _trainers.Count - 1)];
    }
}

