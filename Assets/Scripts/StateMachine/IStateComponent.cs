namespace RogueLike.StateMachine
{
    public interface IStateComponent
    {
        void OnStateEnter();
        void OnStateExit();
    }
}