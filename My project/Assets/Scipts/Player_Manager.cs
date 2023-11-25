using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Manager : MonoBehaviour
{
 
    // Start is called before the first frame update
    public float AttackTmr = 0;
    public int HP = 1;
    public bool canAttack = true;
    public GameObject Ranger;
    public int SwordDamage = 10;
    public int HeavyDamage = 20;
    public Animator PlayerAnimator;
    public GameObject Skeleton;

    public GameObject Body;
    public GameObject LoseText;
    

    
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

       


    }

    public void GetHit(int HitDmg)
    {
        Debug.Log("Taking Damage" + HitDmg);
        HP = HP - HitDmg;
        if (HP <= 0 )
        {
            Debug.Log("Less than 0");
            GameOver();
        }
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

    public void Run(bool isRunning)
    {
            PlayerAnimator.SetBool("isRunning", isRunning);   
    }

    public void GameOver()
    {
        Debug.Log("Gameover");
        LoseText.SetActive(true);
    }

    
}
