using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharacterController;

    public float Speed = 10f;
    public float Gravity = 10f;

    public Transform GroundCheck;
    public float GroundRadius;
    public LayerMask GroundLayer;

    public float JumpHeight = 5f;

    private Vector3 _velocity;
    private bool _onGround;

    public Joystick Joystick;

    [HideInInspector] public Vector3 LastPosition;
    [HideInInspector] public bool IsTeleported = false;

    //I could use a rigidbody, but I wanted to try code my own physics mechanic.
    private void Update()
    {
        _onGround = Physics.CheckSphere(GroundCheck.position, GroundRadius, GroundLayer);
        if (_onGround && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Joystick.Horizontal;
        float z = Joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;
        CharacterController.Move(move * Speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }

        _velocity.y += Gravity * Time.deltaTime;
        CharacterController.Move(_velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_onGround)
        {
            _velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (GroundCheck != null)
        {
            Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
        }
    }
}
