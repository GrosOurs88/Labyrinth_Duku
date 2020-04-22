using UnityEngine;
using System.Collections;

public class AvatarMovement : MonoBehaviour 
{
    //move and rotate
	public float walkSpeed = 10f;
    public float runSpeed = 10f;
    public float sensitivityX = 1f;
    public float offsetForCollisionsWithWalls = 1f;
    float velX = 0;
    float velZ = 0;

    //jump
    public float jumpForce = 10f;
    Rigidbody rb;
    CapsuleCollider col;
    public LayerMask groundLayers;

    void Awake()
	{
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            velX = 0;
            velZ = 0;
            rb.velocity = new Vector3(velX, 0f, velZ);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Move(Vector3.left, -transform.right);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right, transform.right);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Move(Vector3.forward, transform.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back, -transform.forward);           
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();  
        }

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
    }

    private void Move(Vector3 _side, Vector3 _dir)
    {
        if (Physics.Raycast(transform.position, _dir, col.radius + offsetForCollisionsWithWalls))
        {
            Debug.DrawRay(transform.position, _dir, Color.red, 5f);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(_side * runSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.Translate(_side * walkSpeed * Time.deltaTime, Space.Self);
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}