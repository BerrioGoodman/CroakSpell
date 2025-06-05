using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Enviroment groundEnviroment, waterEnviroment;
    [SerializeField] private Transform camTransform;
    private PlayerInputActions playerInputsActions;
    private CharacterController control;
    private Vector2 moveAction;
    private bool jumpAction;
    private bool crouchAction;
    private Vector3 verticalVelocity;
    private bool isInWater;
    private void Awake()
    {
        control = GetComponent<CharacterController>();
        playerInputsActions = new PlayerInputActions();
        playerInputsActions.Player.Move.performed += ctx => moveAction = ctx.ReadValue<Vector2>();
        playerInputsActions.Player.Move.canceled += ctx => moveAction = Vector2.zero;
        playerInputsActions.Player.Jump.started += ctx => jumpAction = true;
        playerInputsActions.Player.Jump.canceled += ctx => jumpAction = false;
        playerInputsActions.Player.Crouch.started += ctx => crouchAction = true;
        playerInputsActions.Player.Crouch.canceled += ctx => crouchAction = false;
    }
    private void OnEnable()
    {
        playerInputsActions.Enable();
    }
    private void OnDisable()
    {
        playerInputsActions.Disable();
    }
    private void Update()
    {
        Enviroment enviroment = isInWater ? waterEnviroment : groundEnviroment;
        //Movement with the third person camera
        Vector3 direction = camTransform.forward * moveAction.y + camTransform.right * moveAction.x;
        direction.y = 0;
        direction.Normalize();
        Vector3 move = direction * enviroment.Speed;
        //Gravity and vertical behavior
        if (isInWater)
        {
            move.y = 0;
            verticalVelocity = Vector3.zero;
            float vertical = 0f;
            if (jumpAction) vertical = 1f;
            else if (crouchAction) vertical = -1f;
            move.y = vertical * enviroment.VerticalSwimSpeed;
        }
        else
        {
            bool grounded = ManualGrounded();
            if (grounded && verticalVelocity.y < 0) verticalVelocity.y = -2f;
            if (grounded && jumpAction)
            {
                verticalVelocity.y = Mathf.Sqrt(enviroment.JumpSpeed * -2f * enviroment.Gravity);
            }
            verticalVelocity.y += enviroment.Gravity * Time.deltaTime;
            move.y = verticalVelocity.y;
        }
        control.Move(move * Time.deltaTime);
        Debug.Log("isInWater" + isInWater);
        Debug.Log("grounded" + control.isGrounded);
    }
    public bool ManualGrounded()
    {
        float detectorLength = 0.3f;
        Vector3 source = transform.position + Vector3.up * 0.1f;
        return Physics.Raycast(source, Vector3.down, detectorLength);
    }
    public void SetInWater(bool inWater)
    {
        isInWater = inWater;
    }
}
