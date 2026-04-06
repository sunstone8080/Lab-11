using System.Collections;
using System.Collections.Generic;
using System.Linq; // Needed for ToList()
using UnityEngine;

public class LoginQueueSimulator : MonoBehaviour
{
   
    private string[] firstNames =
    {
        "Carol", "Adam", "Maria", "John", "Leila", "Chris", "Nina", "David",
        "Sophie", "Liam", "Emma", "Noah", "Olivia", "Lucas", "Ava", "Mason",
        "Isabella", "Ethan", "Mia", "James", "Charlotte", "Benjamin", "Amelia",
        "Elijah", "Harper", "Logan", "Evelyn", "Alexander"
    };

    private char[] lastInitials =
    {
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
    };

    
    private Queue<string> loginQueue = new Queue<string>();

    
    void Start()
    {
        // Create initial queue (4–6 players)
        int initialCount = Random.Range(4, 7);

        for (int i = 0; i < initialCount; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }

        // Convert queue to list
        List<string> queueList = loginQueue.ToList();

        Debug.Log("Initial login queue created. There are "
            + queueList.Count + " players in the queue: "
            + string.Join(", ", queueList));

        // Start routines
        InvokeRepeating(nameof(AddPlayer), 2f, 3f);   
        InvokeRepeating(nameof(LoginPlayer), 4f, 4f); 
    }

    
    string GetRandomPlayerName()
    {
        string first = firstNames[Random.Range(0, firstNames.Length)];
        char last = lastInitials[Random.Range(0, lastInitials.Length)];

        return first + " " + last + ".";
    }


    void AddPlayer()
    {
        string newPlayer = GetRandomPlayerName();
        loginQueue.Enqueue(newPlayer);

        Debug.Log(newPlayer + " is trying to login and added to the login queue.");
    }

    
    void LoginPlayer()
    {
        if (loginQueue.Count > 0)
        {
            string player = loginQueue.Dequeue();
            Debug.Log(player + " is now inside the game.");
        }
        else
        {
            Debug.Log("Login server is idle. No players are waiting.");
        }
    }
}