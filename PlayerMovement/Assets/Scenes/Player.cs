using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float gravityScale = 5f;
    public float speed = 6f;

    public Rigidbody player;
    public Vector3 jump;

    public bool isGrounded;
    public PlayerAnimation playerAnimation;
    Collider collider;
    public GameObject stump;
    public AudioSource audioSource;
    private bool isAttacking = false;
    private Animator animator;
    public AudioClip punch;
    public AudioClip collect;
    public AudioClip moveClip;
    public AudioClip danceClip;
    public AudioClip jumpClip;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
           // playerAnimation.isJumping(true);
        }
       /* else
        {
            playerAnimation.isJumping(false);
        }*/

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnimation.isDancing(true);
            Invoke("ResetDance", 2);
        }*/
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isAttacking = true;
            collider.enabled = true;
           //playerAnimation.isAttacking(true);
            Invoke("ResetAttack", 1);
        }
        
        
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.MovePosition(transform.position + dir * Time.deltaTime * speed);
        if (dir.sqrMagnitude > 0.001f)
        { // If-check as a rotation that looks in no direction isn't valid
            Quaternion forwardsRotation = Quaternion.LookRotation(dir);
            player.MoveRotation(forwardsRotation);
        }
        
       /* if (dir.magnitude < 0.001f)
        {
            playerAnimation.isMoving(false);
        }
        else if (dir.magnitude > 0.001f)
        {
            playerAnimation.isMoving(true);
        }*/
       // playerAnimation.isDancing(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mushroom")
        {
            playerAnimation.isDancing(true);
            new WaitForSeconds(2f);
            //Invoke("ResetDance", 2);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy" && isAttacking)
        {
            new WaitForSeconds(1f);
            Destroy(collision.gameObject, 1f);
        }
        if (collision.gameObject.tag == "tree" && isAttacking)
        {
            new WaitForSeconds(1f);
            Destroy(collision.gameObject, 1f);
            stump.transform.localScale = new Vector3(4.0f,4.0f,4.0f);
            Instantiate(stump, collision.gameObject.transform.position, Quaternion.identity);
        }
    }


    public void ResetDance()
    {
        new WaitForSeconds(2f);
        playerAnimation.isDancing(false);
    }

    private void ResetAttack()
    {
        collider.enabled = false;
        //playerAnimation.isAttacking(false);
        isAttacking = false;
    }

}
