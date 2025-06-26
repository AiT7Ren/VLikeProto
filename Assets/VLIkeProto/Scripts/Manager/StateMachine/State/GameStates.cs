
    public abstract class GameStates : State<GameStates>
    {
        protected GameStates(StatesMachine<GameStates> machine) : base(machine)
        {
        }
    }
