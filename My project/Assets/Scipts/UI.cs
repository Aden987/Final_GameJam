using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI_Element;
    public float timer;
    void Start()
    {
        StartCoroutine(KillTmr());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KillTmr()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(UI_Element.gameObject);

    }
}
