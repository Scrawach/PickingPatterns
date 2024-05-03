using UnityEngine.InputSystem;

public class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();   
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
            return;

        StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.started += OnJumpKeyPressed;
        Input.Movement.IsWalking.started += OnWalkingPressed;
        Input.Movement.IsRunning.started += OnFastRunningPressed;

        Input.Movement.IsWalking.canceled += OnCanceledSpecificMovement;
        Input.Movement.IsRunning.canceled += OnCanceledSpecificMovement;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
        Input.Movement.IsWalking.started -= OnWalkingPressed;
        Input.Movement.IsRunning.started -= OnFastRunningPressed;
        
        Input.Movement.IsWalking.canceled -= OnCanceledSpecificMovement;
        Input.Movement.IsRunning.canceled -= OnCanceledSpecificMovement;
    }

    private void OnCanceledSpecificMovement(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
    private void OnWalkingPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<WalkingState>();
    private void OnFastRunningPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<FastRunningState>();
}
