using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joe_Biden : MonoBehaviour
{
    //SLAM ATTACK
    public GameObject SlamRange;
    public bool Slammable= false;
    public int SlamDmg= 40;
    public float SlamTmr = 7;

    public GameObject TauntRange;
    public bool Tauntable=false;
    public int TauntDmg = 15;
    public float TauntWaitTmr = 4;
    public float TauntTmr = 7;
    public bool isTaunting;

    public GameObject Punch1;
    public GameObject Punch2;
    public bool Punchable = false;
    public int PunchDmg = 25;
    public float PunchTmr = 2;

    public float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Creates delay between attack patterns
        if (attackTimer <=0)
        {
            int r = Random.Range(0, 3);
            switch (1)
            {
                case 0:
                    {
                        Debug.Log("Slam");
                        StartCoroutine(SlamAttack());
                        attackTimer = SlamTmr+2;
                        break;
                    }
                case 1:
                    {
                        Debug.Log("Taunting");
                        Taunt();
                        attackTimer = TauntWaitTmr+1;
                        break;
                    }
                case 2:
                    {
                        Debug.Log("Punch");
                        StartCoroutine(PunchAttack());
                        attackTimer = PunchTmr+1;
                        break;
                    }
            }
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

    //Taunts Player
        if (TauntWaitTmr > 0)
        {
            TauntWaitTmr -= Time.deltaTime;
        }
        else
        {
            isTaunting = false;
        }
        
       
    }

    void DamagePlayer (int Damage)
    {
        Debug.Log("Inflicting damage" +  Damage);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>().GetHit(Damage);
    }

    IEnumerator SlamAttack()
    {
        //Play ANIM

        yield return new WaitForSeconds(SlamTmr);

        if (Slammable == true)
        {   
            DamagePlayer(SlamDmg);
            Debug.Log("Slammed");
        }
    }

    public void Taunt()
    {
        isTaunting = true;
        TauntWaitTmr = 4;   
    }

    public IEnumerator TauntAttack()
    {
        //Play ANIM
        TauntWaitTmr = 0;
        attackTimer = TauntTmr + 3;

        yield return new WaitForSeconds(TauntTmr);
        
        DamagePlayer(TauntDmg);
        Debug.Log("Taunted");


    }

    IEnumerator PunchAttack()
    {
        //Play ANIM

        yield return new WaitForSeconds(PunchTmr);

        if (Punchable == true)
        {
            DamagePlayer(PunchDmg);
            Debug.Log("Punched");
        }
    }


}
