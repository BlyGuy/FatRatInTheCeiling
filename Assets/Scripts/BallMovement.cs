using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public float jumpStrength = 3f;
    public string Xaxis = "Horizontal";
    public string Zaxis = "Vertical";

    public Transform groundCheck;
    public Transform rat;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioManager audioManager;
    Animator animator;
    Rigidbody Ball;

    bool isGrounded;

    private void Start()
    {
        animator = rat.GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("IsStill", false);

        float x = Input.GetAxisRaw(Xaxis);
        float z = Input.GetAxisRaw(Zaxis);
        float y = 0f;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            y = jumpStrength;
            audioManager.Play("PlayerJump");
            animator.SetTrigger("IsJumping");
        }

        Vector3 move = groundCheck.right * x + groundCheck.forward * z * -1;
        Vector3 jump = groundCheck.up * y;
        Vector3 rotate = groundCheck.right * z + groundCheck.forward * x;

        GetComponent<Rigidbody>().velocity += move * speed * Time.deltaTime + jump;
        rat.rotation = Quaternion.LookRotation(rotate);

        if (x == 0f && z == 0f)
        {
            rat.rotation = groundCheck.rotation;
            animator.SetBool("IsStill", true);
        }
    }
}
