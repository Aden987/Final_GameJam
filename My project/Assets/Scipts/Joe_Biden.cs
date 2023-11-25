using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joe_Biden : MonoBehaviour
{
    //SLAM ATTACK
    public GameObject SlamRange;
    public GameObject Amurica;
    public GameObject CallNuke;
    public bool Slammable= false;
    public int SlamDmg= 40;
    public float SlamTmr = 10;
    public float NukeTimer;
    public bool Nukes = false;


    public GameObject TauntRange;
    public GameObject TauntSound;
    public bool Tauntable=false;
    public int TauntDmg = 15;
    public float TauntWaitTmr = 3;
    public float TauntTmr = 1;
    public bool isTaunting;

    public GameObject Punch1;
    public GameObject Punch2;
    public GameObject GunSound;
    public bool Punchable = false;
    public int PunchDmg = 25;
    public float PunchTmr = 5;

    public float attackTimer;
    public Animator JoeAnim;
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
            TauntSound.SetActive(false);
            GunSound.SetActive(false);
            Amurica.SetActive(false);
            CallNuke.SetActive(false);
            int r = Random.Range(0, 3);
            switch (r)
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
                        attackTimer = 7;
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
            JoeAnim.SetBool("Taunt", false);
        }

        if (PunchTmr > 0)
        {
            PunchTmr -= Time.deltaTime;
            if (Punchable == true)
            {
                DamagePlayer(PunchDmg);
                Debug.Log("Punched");
            }
        }
        else
        {
            GunSound.SetActive(false);
        }

        if (NukeTimer > 0)
        {
            NukeTimer -= Time.deltaTime;
        }
        else
        {
            if (Nukes)
            {
                CallNuke.SetActive(true);
                Nukes = false;
            }
          
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
        JoeAnim.SetTrigger("NukeAttack");
        Amurica.SetActive(true);
        Nukes = true;
        NukeTimer = 5.2f;
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
        JoeAnim.SetBool("Taunt", true);
        TauntWaitTmr = 3;   
    }

    public IEnumerator TauntAttack()
    {
        //Play ANIM
        TauntWaitTmr = 0;
        attackTimer = 3;
        JoeAnim.SetTrigger("BitchSlap");
        JoeAnim.SetBool("Taunt", false);
        TauntSound.SetActive(true);
        yield return new WaitForSeconds(2);   
        isTaunting = false;  
        DamagePlayer(TauntDmg);
        Debug.Log("Taunted");


    }

    IEnumerator PunchAttack()
    {
        //Play ANIM
        JoeAnim.SetTrigger("Gun");
        yield return new WaitForSeconds(2f);
        GunSound.SetActive(true);
        PunchTmr = 5;
    }


}
