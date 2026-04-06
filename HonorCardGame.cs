using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HonorCardGame : MonoBehaviour
{
   
    private class Card
    {
        public string rank;
        public string suit;

        public Card(string r, string s)
        {
            rank = r;
            suit = s;
        }

        public override string ToString()
        {
            return rank + suit;
        }
    }

    private List<Card> deck = new List<Card>();
    private List<Card> hand = new List<Card>();

    void Start()
    {
        PlayGame();
    }

    void PlayGame()
    {
        CreateDeck();
        ShuffleDeck();
        DealOpeningHand();

        Debug.Log("I made the initial deck and draw. My hand is: "
            + string.Join(", ", hand));
        while (true)
        {
            if (IsWinningHand())
            {
                Debug.Log("My hand is: " + string.Join(", ", hand) + ". The game is WON.");
                break;
            }
            if (deck.Count == 0)
            {
                Debug.Log("The deck is empty. The game is LOST.");
                break;
            }
            int discardIndex = Random.Range(0, hand.Count);
            Card discarded = hand[discardIndex];
            hand.RemoveAt(discardIndex);
            Card drawn = deck[0];
            deck.RemoveAt(0);
            hand.Add(drawn);
            Debug.Log("I discarded " + discarded + " and drew " + drawn +
                ". My hand is: " + string.Join(", ", hand) +
                ". This is not a winning hand. I will attempt to play another round.");
        }
    }

    void CreateDeck()
    {
        string[] ranks = { "K", "Q", "J", "A" };
        string[] suits = { "\u2660", "\u2663", "\u2665", "\u2666" }; 

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                deck.Add(new Card(rank, suit));
            }
        }
    }

    void ShuffleDeck()
    {
        deck = deck.OrderBy(card => Random.value).ToList();
    }
    void DealOpeningHand()
    {
        for (int i = 0; i < 4; i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }
    bool IsWinningHand()
    {

        var suitGroups = hand.GroupBy(card => card.suit);

 
        return suitGroups.Any(group => group.Count() >= 3);
    }
}