using System;

public class GameStatesMachine : StatesMachine<GameStates>
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
    }
    
    
    
    
}

