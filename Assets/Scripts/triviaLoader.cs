using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class triviaLoader : MonoBehaviour
{
    [System.Serializable]
    public class TriviaData
    {
        public List<string> trivia;
    }

    public TextMeshProUGUI triviaText; // Reference to the TextMeshPro component

    private TriviaData triviaData;

    void Start()
    {
        LoadTrivia();
        DisplayRandomTrivia();
    }

    void LoadTrivia()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Trivia");
        if (jsonFile != null)
        {
            triviaData = JsonUtility.FromJson<TriviaData>(jsonFile.text);
            Debug.Log("Trivia JSON loaded successfully!");
        }
        else
        {
            Debug.LogError("Trivia file not found!");
        }
    }

    void DisplayRandomTrivia()
    {
        if (triviaData != null && triviaData.trivia.Count > 0)
        {
            string randomFact = triviaData.trivia[Random.Range(0, triviaData.trivia.Count)];
            triviaText.text = randomFact; // Set the text on the TextMeshProUGUI component
        }
    }
}
