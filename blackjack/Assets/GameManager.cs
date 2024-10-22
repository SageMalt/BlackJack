using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cardsLayout;
    [SerializeField] GameObject cardPref;
    [SerializeField] Text cardCounter;

    [SerializeField] List<Card> cardsInDeck;
    [SerializeField] List<Card> playerCards;
    [SerializeField] List<Card> outCards;

    [SerializeField] Canvas loseCanvas;
    [SerializeField] Canvas wonCanvas;

    [SerializeField] Button[] buttons;

    void Start()
    {
        for ( int i = 0 ; i < 2 ; i++ ) // магическое число надо убрать
        {
            GetCard();
        } 
        cardCounter.text = cardsInDeck.Count.ToString();
    }

    public void GetCard()
    {
        int cardNum = Random.Range(0,cardsInDeck.Count);
        Card cardInfo = cardsInDeck[cardNum];

        playerCards.Add(cardsInDeck[cardNum]);
        cardsInDeck.Remove(cardsInDeck[cardNum]);

        CardComponent card = Instantiate(cardPref , cardsLayout.transform).GetComponent<CardComponent>();
        card.SetName(cardInfo.name);
        CheckCardWeight();
    }
    public void SkipCard()
    {
        int cardNum = Random.Range(0,cardsInDeck.Count);

        outCards.Add(cardsInDeck[cardNum]);
        cardsInDeck.Remove(cardsInDeck[cardNum]);
        CheckCardWeight();
    }
    void CheckCardWeight()
    {
        int sumWeight = 0;
        foreach ( Card card in playerCards )
            sumWeight += card.weight;

        if (sumWeight > 21) // еще одно магичекое число
            Lose();
        else if (sumWeight == 21)
            Won();

        cardCounter.text = cardsInDeck.Count.ToString();
    }

    void Lose()
    {
        loseCanvas.enabled = true;
        foreach (Button button in buttons)
            button.interactable = false;
    }
    void Won()
    {
        wonCanvas.enabled = true;
            foreach (Button button in buttons)
            button.interactable = false;
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);// хардкод
    }
}

[System.Serializable]
struct Card
{
    public string name;
    public int weight;
    Card(string name , int weight)
    {
        this.name = name ;
        this.weight = weight ;
    }
}
