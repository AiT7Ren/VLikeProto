using System;
using UnityEngine;

namespace VLIkeProto.Scripts.Manager.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        public void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (GameStatesMachine.Instance==null)
            {
                GameObject gameStatesGameObject = new GameObject("GameStateMachine");
                gameStatesGameObject.AddComponent<GameStatesMachine>();
            }
        }


        //TODO
       //1)GameManager 
        //StateMachete for gameState (gameplay and shop)
            //Added Generic SM and Create SM for GameState(singilton manager)
                //Need Add State
       //2)ObjectPool (generic)
        //EnemyPool, ExpObj, ProjectileObj
       //3)Fabric for Instance GO
        //Enemy, Projectiles=>Vfx, Exp, PickUp, Player 
        
        
        
        
    }
}
