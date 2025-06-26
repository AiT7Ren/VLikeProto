using System;
using System.Collections.Generic;
using UnityEngine;


    public class StatesMachine<T> :MonoBehaviour where T : State<T> //TryMono but mb add to manager
    {
        private T _currentState;
        private Dictionary<Type,T> _states = new Dictionary<Type,T>();
        
        public void RegisterState<TState>(TState state) where TState : T
        {
            Type stateType = typeof(TState);
            if (_states.ContainsKey(stateType)) return;
            _states[stateType] = state;
        }

        public void ChangeState<TState>() where TState : T
        {
            Type stateType = typeof(TState);
            if (_states.TryGetValue(stateType, out T state))
            {
                if(state==_currentState)return;
                _currentState?.Exit();
                _currentState=state;
                _currentState.Enter();
            }
            else
            {
                //TODO add register
                throw new Exception("NO regestraterState");
            }
        }

        public virtual void Update()
        {
            _currentState?.Update();
        }

        public virtual void FixedUpdate() //? md don't need it
        {
            _currentState?.FixedUpdate();
        }
    }

