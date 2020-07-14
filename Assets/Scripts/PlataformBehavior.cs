using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlataformBehavior : MonoBehaviour
{

    public float speed = 0f;
    public float jumpForce = 0f;
    public bool die = false;

    private bool isOnFloor = false;

    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.Play("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        if (isOnFloor)
            anim.speed = 0;
        else
            anim.speed = 1;
        if (die)
            SceneManager.LoadScene("SampleScene");
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
        }
    }
}
