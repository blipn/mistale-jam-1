using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRunTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Hide), 5);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
