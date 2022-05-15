using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldNotes : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                //Generates the score and effect for a hit.
                if (canBePressed == true)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position = new Vector3(-5, 4, 0), hitEffect.transform.rotation);
                }
                
                
            }
        }
    }
  
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    //Generates the score and effect for a miss
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMiss();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
