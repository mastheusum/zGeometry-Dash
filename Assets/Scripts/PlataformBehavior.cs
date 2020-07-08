using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformBehavior : MonoBehaviour
{

    public float speed = 0f;
    public float jumpForce = 0f;

    public bool isOnFloor = false;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        rig.AddTorque(-2);
        if (rig.velocity.y == 0) isOnFloor = true;
    }

    void Movement()
    {
        rig.position += new Vector2(Input.GetAxisRaw("Horizontal"), 0f) * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetAxisRaw("Jump") != 0 && isOnFloor)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isOnFloor = false;
        }
    }
}
