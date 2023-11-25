using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialText;
    int tutorialIndex = 0;
    float waitTime = 3f;

    public GameObject player;
    public GameObject arrowOne;
    public GameObject arrowTwo;
    public GameObject platArrowOne;
    public GameObject platArrowTwo;
    public GameObject nextLevel;
    CameraFollow cam;
    bool epl = false;
    public GameObject explanation;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;
        cam = FindObjectOfType<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tutorialText.Length; i++)
        {
            if (i == tutorialIndex)
            {
                tutorialText[i].SetActive(true);
            }
            else
            {
                tutorialText[i].SetActive(false);
            }
        }

        if (tutorialIndex == 0 && epl == true)
        {
            if(waitTime < 0)
            {
                tutorialIndex++;
                player.GetComponent<PlayerController>().enabled = true;
                waitTime = 3f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if(tutorialIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) 
            {
                tutorialIndex++;
            }
        }
        if (tutorialIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                tutorialIndex++;
            }
        }
        if (tutorialIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialIndex++;
            }
        }
        if (tutorialIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                tutorialIndex++;
            }
        }
        if (tutorialIndex == 5)
        {
            if (waitTime < 0)
            {
                tutorialIndex++;
                arrowOne.SetActive(true);
                waitTime = 3f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (tutorialIndex == 6)
        {
            //freeze on green mark
            if (Input.GetKeyDown(KeyCode.E) && arrowOne.GetComponent<ArrowIndicators>().onMark == true)
            {
                tutorialIndex++;
            }
        }
        if (tutorialIndex == 7)
        {
            arrowOne.SetActive(false);
            //jump on platform
            if (platArrowOne.GetComponent<ArrowIndicators>().onMark == true)
            {
                tutorialIndex++;
                arrowTwo.SetActive(true);
            }
        }
        if (tutorialIndex == 8 && arrowTwo.GetComponent<ArrowIndicators>().onMark == true)
        {
            //crouched on green mark
            if (Input.GetKeyDown(KeyCode.C))
            {
                tutorialIndex++;
            }
        }
        if (tutorialIndex == 9)
        {
            arrowTwo.SetActive(false);
            if (waitTime < 0)
            {
                tutorialIndex++;
                waitTime = 3f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (tutorialIndex == 10)
        {
            //check player stuck
            if (cam.targets[0].GetComponent<PlayerController>().gumStuck == true)
            {
                tutorialIndex++;
            }
            
        }
        if (tutorialIndex == 11)
        {
            if (platArrowTwo.GetComponent<ArrowIndicators>().onMark == true)
            {
                tutorialIndex++;
                nextLevel.SetActive(true);
            }

        }
    }

    public void Next()
    {
        explanation.SetActive(false);
        epl = true;
    }
}
