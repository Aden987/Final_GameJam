using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Manager : MonoBehaviour
{
 
    // Start is called before the first frame update
    public float AttackTmr = 0;
    public int HP = 50;
    public bool canAttack = true;
    public GameObject Ranger;
    public int SwordDamage = 10;
    public int HeavyDamage = 20;
    public Animator PlayerAnimator;
    public GameObject Skeleton;

    public GameObject Body;
    

    
    void Start()
    {
        PlayerAnimator = Skeleton.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if you can attack
        if (canAttack == false)
        {
           Debug.Log("Cant attack");
            AttackTmr -= Time.deltaTime;
            if (AttackTmr < 0 )
            {
                canAttack = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
         
            if (canAttack)
            {
                Debug.Log("light");
                canAttack = false;
                SwordAttack();
                AttackTmr = 0.7f;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            if (canAttack)
            {
                Debug.Log("heavy");
                canAttack = false;
                HeavyAttack();
                AttackTmr = 1.5f;
            }
        }
/*
        if (Mathf.Approximately(Body.GetComponent<Rigidbody>().velocity.y, 0))
        {
            PlayerAnimator.SetBool("isRunning", true);
        }
        else
        {
            PlayerAnimator.SetBool("isRunning", false);
        }*/


    }

    public void GetHit(int HitDmg)
    {
        HP -= HitDmg;
    }

    public void SwordAttack()
    {
        Ranger.GetComponent<Can_Hit>().Attack(SwordDamage);
        PlayerAnimator.SetTrigger("Light");
    }

    public void HeavyAttack()
    {
        Ranger.GetComponent<Can_Hit>().Attack(HeavyDamage);
        PlayerAnimator.SetTrigger("Heavy");
    }

    
}
