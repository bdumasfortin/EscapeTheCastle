using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Entity : MonoBehaviour
{
    [Header("Jump and gravity")]
    [SerializeField] private float _jumpHeight = 9.0f;
    [SerializeField] private float _gravityValue = 9.81f;
    [SerializeField] private float _fallModifier = 2.5f;

    //protected Animator _animator;
    private Vector3 _velocity = Vector3.zero;
    private CharacterController _characterController;

    public bool IsGrounded => _characterController.isGrounded;
    public Vector3 Velocity => _velocity;

    protected void Start()
    {
        //_animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    protected void Update()
    {
    }

    private void LateUpdate()
    {
        ApplyGravity();
        //_animator.SetBool(Constants.ANIMATION_TRIGGER_IS_GROUNDED, IsGrounded);
        _characterController.Move(_velocity * Time.deltaTime);
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void Jump()
    {
        if (!IsGrounded) return;

        //_animator.SetTrigger(Constants.ANIMATION_TRIGGER_JUMP);
        _velocity.y = _jumpHeight;
    }

    private void ApplyGravity()
    {
        if (!IsGrounded)
            _velocity.y -= _gravityValue * _fallModifier * Time.deltaTime;
    }
}
