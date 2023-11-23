using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    Rigidbody rb;
    public bool isOnGround = true;
    GameObject spawnPoint;
    public GameObject player;
    bool gumStuck = false;
    bool crouch = false;
    float upSpeed;
    CameraFollow cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraFollow>();
        spawnPoint = GameObject.Find("SpawnPoint");
        cam.targets.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            upSpeed = 500f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isOnGround = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && isOnGround)
        {
            SpawnNewBear();
        }
        if (Input.GetKeyDown(KeyCode.C) && isOnGround)
        {
            crouch = true;
            SpawnNewBear();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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
            upSpeed += 100f;
            if (upSpeed >= 700f)
            {
                upSpeed = 700f;
            }
            rb.AddForce(new Vector3(0, upSpeed, 0));
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gum" && gumStuck == false)
        {
            gumStuck = true;
            //Debug.Log("gum");
            SpawnNewBear();
        }
    }

    private void SpawnNewBear()
    {
        Instantiate(player, spawnPoint.transform.position,Quaternion.identity);
        if (crouch == true)
        {
            gameObject.transform.localScale = new Vector3 (1f, 0.5f, 1f);
            gameObject.tag = "bounce";
        }
        rb.constraints = RigidbodyConstraints.FreezeAll;
        cam.targets.Remove(gameObject.transform);
        gameObject.GetComponent<PlayerController>().enabled = false;
    }
}
