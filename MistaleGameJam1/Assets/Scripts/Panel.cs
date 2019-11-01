using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Dialog DialogManager;
    private bool activatedOnce = false;
    public int dialogStartIndex;
    public int dialogEndIndex;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (activatedOnce == false)
        {
            DialogManager.StartDialog(dialogStartIndex, dialogEndIndex);
            activatedOnce = true;
        }
    }
}
