using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Enviroments")]
    [SerializeField] private Enviroment groundEnviroment, waterEnviroment;
    [Header("Camera Reference")]
    [SerializeField] private Transform camTransform;
    private PlayerInputActions playerInputsActions;
    private CharacterController control;
    //Parameters for the player inputs
    private Vector2 moveAction;
    private bool jumpAction;
    private bool crouchAction;
    private bool skill1, skill2, skill3;
    private Vector3 verticalVelocity;
    private bool isInWater;

    private void Awake()
    {
        //We conect all the buttons with the parameters
        control = GetComponent<CharacterController>();
        playerInputsActions = new PlayerInputActions();
        playerInputsActions.Player.Move.performed += ctx => moveAction = ctx.ReadValue<Vector2>();
        playerInputsActions.Player.Move.canceled += ctx => moveAction = Vector2.zero;
        playerInputsActions.Player.Jump.started += ctx => jumpAction = true;
        playerInputsActions.Player.Jump.canceled += ctx => jumpAction = false;
        playerInputsActions.Player.Crouch.started += ctx => crouchAction = true;
        playerInputsActions.Player.Crouch.canceled += ctx => crouchAction = false;
        playerInputsActions.Player.Skill1.started += ctx => skill1 = true;
        playerInputsActions.Player.Skill1.canceled += ctx => skill1 = false;
        playerInputsActions.Player.Skill2.started += ctx => skill2 = true;
        playerInputsActions.Player.Skill2.canceled += ctx => skill2 = false;
        playerInputsActions.Player.Skill3.started += ctx => skill3 = true;
        playerInputsActions.Player.Skill3.canceled += ctx => skill3 = false;
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
        //We review if our player is in the water what scriptable object might be used
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
            verticalVelocity = Vector3.zero;//When we're in the water, gravity is zero
            float vertical = 0f;
            if (jumpAction) vertical = 1f;
            else if (crouchAction) vertical = -1f;
            move.y = vertical * enviroment.VerticalSwimSpeed;
        }
        else
        {
            //If we're not in the water, then we are grounded or jumping
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
        //We make our player be grounded with a raycast
        float detectorLength = 0.3f;
        Vector3 source = transform.position + Vector3.up * 0.1f;
        return Physics.Raycast(source, Vector3.down, detectorLength);
    }
    public void SetInWater(bool inWater)
    {
        //For the trigger detector of the water
        isInWater = inWater;
    }
}
