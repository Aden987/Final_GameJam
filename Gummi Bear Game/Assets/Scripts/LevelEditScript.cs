using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEditScript : MonoBehaviour
{
    public TextMeshProUGUI bearNumTxt;
    public int maxBearNum;
    public int currentBearNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        bearNumTxt.text = currentBearNum.ToString() + "/" + maxBearNum.ToString();
    }

    public void AddBear()
    {
        currentBearNum++;
        bearNumTxt.text = currentBearNum.ToString() + "/" + maxBearNum.ToString();
    }
}
