using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

public class DuplicateNameDetector : MonoBehaviour
{
   
    private string[] firstNames =
    {
        "Carol", "Adam", "Maria", "John", "Leila", "Chris", "Nina", "David",
        "Sophie", "Liam", "Emma", "Noah", "Olivia", "Lucas", "Ava", "Mason",
        "Isabella", "Ethan", "Mia", "James", "Charlotte", "Benjamin", "Amelia",
        "Elijah", "Harper", "Logan", "Evelyn", "Alexander"
    };

    void Start()
    {
        RunDuplicateDetection();
    }

    void RunDuplicateDetection()
    {
      
        List<string> nameArray = new List<string>();

        for (int i = 0; i < 15; i++)
        {
            string randomName = firstNames[Random.Range(0, firstNames.Length)];
            nameArray.Add(randomName);
        }

        Debug.Log("Created the name array: " + string.Join(", ", nameArray));

       
        HashSet<string> seen = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (string name in nameArray)
        {
            
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }
        }

      
        if (duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: "
                + string.Join(", ", duplicates));
        }
        else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}