using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    
    float HorizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
                HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));


                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }

                if (Input.GetButtonDown("Crouch"))
                {
                    crouch = false;


                }
                else if (Input.GetButtonUp("Crouch"))
                {
                    crouch = false;

                }
    }


    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate ()
    {
        // Character Move
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
 