using System;

public class GameStatesMachine : StatesMachine
{
    public static GameStatesMachine Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializationStateMachine();
    }

    private void InitializationStateMachine()
    {
        RegisterState(new GameState(this));
        RegisterState(new ShopState(this));
        ChangeState<GameState>();
    }
}

