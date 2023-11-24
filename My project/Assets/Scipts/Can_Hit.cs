using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can_Hit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Targets = new GameObject[10];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //scans through array to find first empty spot
       int first = 0;
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
            for (int i = 0; i < 10; i++)
            {
                if (Targets[i] = null)
                {
                    if (first == 0)
                    {
                        first = i;
                    }   
                }
               
            }

            Targets[first] = other.gameObject;
        }
    }

    public void Attack(int Damage)
    {
        for (int i = 0; i < 10; i++)
        {
            if (Targets[i] != null)
            {
                Targets[i].GetComponent<Enemy_Manager>().getHit(Damage);
            }
           
        } 
    }
}
