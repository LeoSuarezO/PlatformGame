using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rbd;
    private Animator animator;
    private float horizontal;  
    public float speed;
    public float jumpForce;
    private int jumps;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        jumps = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if(horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("running", horizontal != 0.0f);

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(jumps<=1){
            rbd.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            jumps++;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D obj) {
        if(obj.collider.tag=="Floor"){
            jumps=0;
        }
    }

    private void FixedUpdate() {
        rbd.velocity = new Vector2(horizontal*speed, rbd.velocity.y);
    }
}
