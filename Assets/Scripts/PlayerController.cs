using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _characterController;

    public float movementSpeed = 1;
    public float gravity = -9.8f;
    public float jump = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;
 
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y <0)
        {
            _velocity.y = -2f;
        }
        
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        _characterController.Move(move * (movementSpeed * Time.deltaTime));

        if (Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }
}
