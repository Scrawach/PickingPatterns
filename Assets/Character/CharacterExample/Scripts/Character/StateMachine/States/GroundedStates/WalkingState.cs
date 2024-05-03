public class WalkingState : GroundedState
{
    private readonly RunningStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) =>
        _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.WalkingSpeed;
        View.StarWalking();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopWalking();
    }
}