using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 2f;

    private CharacterController characon;
    private Animator animator;
    private Vector3 velocity;
    private Vector3 oldvelocity;
    
	// Use this for initialization
	void Start () {
        characon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (characon.isGrounded)
        {
            velocity = Vector3.zero;
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if(velocity.magnitude > 0f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characon.Move(velocity * Time.deltaTime);
	}
}
