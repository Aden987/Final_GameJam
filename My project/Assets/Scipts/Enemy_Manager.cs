using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private int hp = 20;
    public int Power;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(int Damage)
    {
        hp -= Damage;
        Debug.Log("I took damage");
    }
}
