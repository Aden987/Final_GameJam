using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicators : MonoBehaviour
{
    public bool onMark = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            onMark = true;
        }
    }
}
