using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float AttackTmr = 0;
    public bool canAttack = true;
    public GameObject Ranger;
    public int SwordDamage = 10;
    public int HeavyDamage = 20;
    void Start()
    {
        
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

    public void SwordAttack()
    {
        Ranger.GetComponent<Can_Hit>().Attack(SwordDamage);  
    }

    public void HeavyAttack()
    {
        Ranger.GetComponent<Can_Hit>().Attack(HeavyDamage);
    }
}
