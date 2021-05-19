using UnityEngine;

[RequireComponent(typeof(Entity))]
public class MovementController : MonoBehaviour
{
    [Header("Movement speeds")]
    [SerializeField] private float _runSpeed = 6.5f;
    [SerializeField] private float _turnSpeed = 3f;

    private Entity _entity;

    void Start()
    {
        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(InputUtils.BUTTON_JUMP))
            _entity.Jump();

        var moveDirection = GetMovementRelativeToPlayer();

        HandleAnimations();

        if (_entity.IsGrounded)
            _entity.SetVelocity(CalculateNewVelocity(moveDirection));
    }

    //TODO: Move this out of movement controller
    private void HandleAnimations()
    {
        var verInput = Input.GetAxisRaw("Vertical");

        if (verInput < 0)
            GetComponent<Animator>()?.SetInteger("State", 2);
        else if (verInput > 0)
            GetComponent<Animator>()?.SetInteger("State", 1);
        else
            GetComponent<Animator>()?.SetInteger("State", 0);
    }

    private float GetCurrentMoveSpeed()
    {
        return _runSpeed;
    }

    private Vector3 CalculateNewVelocity(Vector3 moveDirection)
    {
        Vector3 newVelocity = moveDirection.normalized * GetCurrentMoveSpeed();
        newVelocity.y = _entity.Velocity.y;
        return newVelocity;
    }

    private Vector3 GetMovementRelativeToPlayer()
    {
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * Time.deltaTime * _turnSpeed * 80f, 0f);
        return transform.forward * Input.GetAxisRaw("Vertical");
    }
}
