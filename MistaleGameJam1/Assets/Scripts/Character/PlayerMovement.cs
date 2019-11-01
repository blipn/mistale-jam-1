using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public CircleCollider2D fieldAttack;
    public GameObject effects;

    public float runSpeed = 40f;
    public AudioSource sfAttack;

    public GameObject inventory;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool m_stopMove = false;
    Rigidbody2D m_rgPlayer;

    private void Start()
    {
        m_rgPlayer = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_stopMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Fire1") && !inventory.activeSelf)
            {
                animator.SetBool("IsAttacking", true);
                runSpeed = 0;
                if (fieldAttack != null && !animator.GetBool("IsJumping"))
                {
                    sfAttack.Play();
                    fieldAttack.enabled = true;
                }
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("IsAttacking", false);
                StartCoroutine(GoAfterAttack());
                if (fieldAttack != null)
                    fieldAttack.enabled = false;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void StopMove()
    {
        m_stopMove = true;
        animator.SetFloat("Speed", 0f);
        m_rgPlayer.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void GoMove()
    {
        m_stopMove = false;
        m_rgPlayer.constraints = RigidbodyConstraints2D.None;
        m_rgPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    IEnumerator GoAfterAttack()
    {
        yield return new WaitForSeconds(0.4f);
        runSpeed = 120f;
    }
}
