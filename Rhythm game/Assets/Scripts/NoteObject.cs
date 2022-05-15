using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                //Generates the score and effect for a hit.
                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position = new Vector3 (-5, 4, 0), hitEffect.transform.rotation);
                }
                //Generates the score and effect for a good hit
                else if(Mathf.Abs(transform.position.y) > 0.10f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position = new Vector3 (-5, 5, 0), goodEffect.transform.rotation);
                }
                //Generates the score and effect for a perfect hit
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position = new Vector3(5, 5, 0), perfectEffect.transform.rotation);
                }
            }
        }
    }
    // Version used for mobile touch controlls or wanting to use mouse instead of the buttons
    void OnMouseDown()
    {
        if (canBePressed)
        {
            gameObject.SetActive(false);

            //GameManager.instance.NoteHit();

            //Generates the score and effect for a hit.
            if (Mathf.Abs(transform.position.y) > 0.25)
            {
                Debug.Log("Hit");
                GameManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position = new Vector3(-5, 4, 0), hitEffect.transform.rotation);
            }
            //Generates the score and effect for a good hit
            else if (Mathf.Abs(transform.position.y) > 0.10f)
            {
                Debug.Log("Good");
                GameManager.instance.GoodHit();
                Instantiate(goodEffect, transform.position = new Vector3(-5, 5, 0), goodEffect.transform.rotation);
            }
            //Generates the score and effect for a perfect hit
            else
            {
                Debug.Log("Perfect");
                GameManager.instance.PerfectHit();
                Instantiate(perfectEffect, transform.position = new Vector3(5, 5, 0), perfectEffect.transform.rotation);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    //2 set of locations for the miss effect
    private List<Vector3> m_positions = new List<Vector3>
    {
        new Vector3(3, 1, 0),
        new Vector3(-3, 1, 0),
    };
    //chooses between the two random positions to spawn the miss effect
    Vector3 GetRandomPosition()
    {
        Vector3 position = m_positions[Random.Range(0, m_positions.Count)];
        m_positions.Remove(position);
        return position;
    }

    //Generates the score and effect for a miss
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMiss();
            Instantiate(missEffect, transform.position = GetRandomPosition() , missEffect.transform.rotation);
            Destroy(gameObject);
        }
    }

}
