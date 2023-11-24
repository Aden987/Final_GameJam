using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidenCanHit : MonoBehaviour
{
    // Start is called before the first frame update
    public int AttackType;
    public GameObject Biden;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


            switch (AttackType)
            {
                case 0:
                    Biden.GetComponent<Joe_Biden>().Slammable = true; Debug.Log("Can Slam"); break;
                case 2:
                    Biden.GetComponent<Joe_Biden>().Punchable = true; break;


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (AttackType)
            {
                case 0:
                    Biden.GetComponent<Joe_Biden>().Slammable = false; Debug.Log("Cant Slam"); break;
                case 1:
                    Biden.GetComponent<Joe_Biden>().Punchable = false; break;
            }
        }
    }
}
