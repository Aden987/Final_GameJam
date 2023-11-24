using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 20;
    public int Power;
    public bool Biden = false;
    void Start()
    {
        if (Biden == true)
        {
            hp = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(int Damage)
    {
        if (Biden == true)
        {
            if (this.GetComponent<Joe_Biden>().isTaunting == true)
            {
                StartCoroutine(this.GetComponent<Joe_Biden>().TauntAttack());
            }
            else
            {
                hp -= Damage;
                Debug.Log("I took damage");
                RunAway();
            }
        }
        else
        {
            hp -= Damage;
            Debug.Log("I took damage");
            RunAway();
        }
      

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Can_Hit.Targets[i] == this.gameObject)
            {
                Can_Hit.Targets[i] = null;
            }
        }

        Destroy(this.gameObject);
        
    }

    public void RunAway()
    {
        ///NAVMESH SHIT
    }


}
