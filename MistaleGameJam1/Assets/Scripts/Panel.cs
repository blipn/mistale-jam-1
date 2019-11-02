using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Panel : MonoBehaviour
{
    private bool activatedOnce;
    public bool isScrollingStarterPanel;
    public int dialogEndIndex;
    public Dialog dialogManager;
    public int dialogStartIndex;
    public GameObject interlocuteur1;
    public GameObject interlocuteur2;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activatedOnce)
        {
            dialogManager.StartDialog(dialogStartIndex, dialogEndIndex, interlocuteur1, interlocuteur2, isScrollingStarterPanel);
            activatedOnce = true;
        }
    }
}
