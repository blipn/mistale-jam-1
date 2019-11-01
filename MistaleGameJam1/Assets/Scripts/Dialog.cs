using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool activatedOnce=false;
    private int startIndex;
    private int endIndex;

    public GameObject continueButton;
    public PlayerMovement playerMovement;

    private void Update()
    {
        if (textDisplay.text == sentences[this.startIndex])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[this.startIndex].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartDialog(int dialogStartIndex, int dialogEndIndex)
    {
        this.startIndex = dialogStartIndex;
        this.endIndex = dialogEndIndex;
        StartCoroutine(Type());
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (this.startIndex < this.endIndex)
        {
            this.startIndex++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

}
