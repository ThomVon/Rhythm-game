using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideScript : MonoBehaviour
{
    public GameObject hideScript;

    void Update()
    {
        if (Input.anyKeyDown)
            {
                hideScript.SetActive(false);
            }
    }
}
