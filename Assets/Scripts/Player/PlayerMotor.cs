using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float gravity= -9.8f;
    public float speed = 5f;
    public float jumpHeight = 3f;
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale = new Vector3(1, 1f, 1);

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = crouchScale;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = playerScale;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
    }
    public void ProcessMove(Vector2 input )
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection( moveDirection) * speed * Time.deltaTime );
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);

    }
    public void Jump()
        {
            if (isGrounded) 
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            }
        }
}
