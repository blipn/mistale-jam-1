using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Tooltip("In seconds")]
    public int DurationOfLevel = 60;    
    private int CurrentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScoreKeeping", 0f, 1f);
    }


    private void ScoreKeeping()
    {
        if (CurrentScore >= DurationOfLevel)
        {
            SceneManager.LoadScene(3);
        }

        text.text = (DurationOfLevel - CurrentScore).ToString();
        CurrentScore += 1;
    }
}
