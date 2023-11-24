using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;

    public float Speed = 6f;
    public float turnSmoothtime = 0.1f;
    float smoothVelocity;
   

    public bool Grounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

      

        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSmoothtime);
            transform.rotation = Quaternion.Euler(0f,angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move (moveDirection.normalized*Speed*Time.deltaTime);
           
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
          //Jump
        }
    }
}
