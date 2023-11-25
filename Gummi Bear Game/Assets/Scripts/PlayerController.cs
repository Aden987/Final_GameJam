using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    Rigidbody rb;
    public bool isOnGround = true;
    GameObject spawnPoint;
    public GameObject player;
    public bool gumStuck = false;
    bool crouch = false;
    float upSpeed;
    CameraFollow cam;
    LevelEditScript lvlEdit;
    Animator animator;
    Vector3 vel;
    public GameObject nextLevel;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraFollow>();
        lvlEdit = FindObjectOfType<LevelEditScript>();
        spawnPoint = GameObject.Find("SpawnPoint");
        cam.targets.Add(gameObject.transform);
        lvlEdit.AddBear();
        animator = GetComponent<Animator>();
        //Rigidbody r = gameObject.GetComponent<Rigidbody>();
        vel = rb.velocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            upSpeed = 300f;
        }

        ;
        //if (vel.magnitude == 0)
        //{
        //    animator.SetInteger("Anim", 0);
        //}

        if (Input.GetKeyDown(KeyCode.E) && isOnGround)
        {
            animator.SetInteger("Anim", 4);
            SpawnNewBear();
        }
        if (Input.GetKeyDown(KeyCode.C) && isOnGround)
        {
            crouch = true;
            animator.SetInteger("Anim", 3);
            SpawnNewBear();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            animator.SetInteger("Anim", 2);
            isOnGround = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            if (isOnGround == true)
            {
                animator.SetInteger("Anim", 1);
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            if (isOnGround)
            {
                animator.SetInteger("Anim", 1);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (isOnGround)
            {
                animator.SetInteger("Anim", 1);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (isOnGround)
            {
                animator.SetInteger("Anim", 1);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Player")
        {
            isOnGround = true;
        }
        if (collision.gameObject.tag == "bounce" && isOnGround == false)
        {
            upSpeed += 10f;
            if (upSpeed >= 330f)
            {
                upSpeed = 330f;
            }
            rb.AddForce(new Vector3(0, upSpeed, 0));
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gum" && gumStuck == false)
        {
            gumStuck = true;
            //transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            SpawnNewBear();
        }
        if (other.gameObject.tag == "respawn")
        {
            player.transform.position = spawnPoint.transform.position;
        }
        if (other.gameObject.name == "LevelTransition1")
        {
            nextLevel.SetActive(true);
        }
    }

    private void SpawnNewBear()
    {
        if(lvlEdit.currentBearNum < lvlEdit.maxBearNum)
        {
            Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
            if (crouch == true)
            {
                //gameObject.transform.localScale = new Vector3(1f, 0.5f, 1f);
                gameObject.tag = "bounce";
                gameObject.transform.GetChild(0).tag = "bounce";
            }
            //if (gumStuck == true)
            //{
            //    //gameObject.transform.localScale = new Vector3(1f, 0.5f, 1f);
            //    //gameObject.tag = "bounce";
            //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1);
            //}
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cam.targets.Remove(gameObject.transform);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            loseScreen.SetActive(true);
        }
        
    }
}
