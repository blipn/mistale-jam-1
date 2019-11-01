using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private bool activatedOnce=false;

    public GameObject continueButton;
    private int endIndex;
    private int index;
    public PlayerMovement playerMovement;
    public string[] sentences;

    private GameObject speaker1;
    private GameObject speaker2;
    private int startIndex;
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;

    private void Update()
    {
        if (Input.GetKeyDown("space") && continueButton.activeSelf == true)
        {
            NextSentence();
        }
        
        if (textDisplay.text == sentences[this.startIndex])
        {
            continueButton.SetActive(true);
        }
    }

    private IEnumerator Type()
    {
        foreach(char letter in sentences[this.startIndex].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartDialog(int dialogStartIndex, int dialogEndIndex, GameObject interlocuteur1, 
        GameObject interlocuteur2)
    {
        this.startIndex = dialogStartIndex;
        this.endIndex = dialogEndIndex;
        this.speaker1 = interlocuteur1;
        this.speaker2 = interlocuteur2;
        this.speaker1.SetActive(true);
        playerMovement.StopMove();
        StartCoroutine(Type());
    }

    //TODO Gérer cas du startindex impair, modulo est pas ouf
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (this.startIndex < this.endIndex)
        {
            this.startIndex++;
            textDisplay.text = "";
            StartCoroutine(Type());
            if (startIndex % 2 == 1)
            {
                this.speaker1.SetActive(false);
                this.speaker2.SetActive(true);
            }
            else
            {
                this.speaker1.SetActive(true);
                this.speaker2.SetActive(false);
            }
        }
        else
        {
            textDisplay.text = "";
            playerMovement.GoMove();
            continueButton.SetActive(false);
            this.speaker1.SetActive(false);
            this.speaker2.SetActive(false);
        }
    }
}
