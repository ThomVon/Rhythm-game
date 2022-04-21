using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public GameObject animationStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            animationStart.SetActive(true);
        }
    }
}
