using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformBehavior : MonoBehaviour
{

    public float speed = 0f;
    public float jumpForce = 0f;

    private bool isOnFloor = false;
    private bool canDie = false;

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
    }

    void Movement()
    {
        rig.position += new Vector2(1f, 0f) * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetAxisRaw("Jump") != 0 && isOnFloor)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isOnFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tiles")
        {
            isOnFloor = true;
            print(rig.velocity);
        }
        else if (collision.gameObject.tag == "Danger/Spike")
        {
            Destroy(gameObject);
        }
    }
}
