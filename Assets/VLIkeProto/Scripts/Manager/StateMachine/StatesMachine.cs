using System;
using System.Collections.Generic;
using UnityEngine;
public abstract class StatesMachine:MonoBehaviour
    {
        protected SMState _currentState; 
        protected Dictionary<Type,SMState> _states = new Dictionary<Type,SMState>();
        
        public void RegisterState<T>(T state) where T:SMState
        {
            Type stateType = typeof(T);
            if (_states.ContainsKey(stateType)) return;
            _states[stateType] = state;
            Debug.Log(stateType.Name + " registered");
        }

        public void ChangeState<T>() where T : SMState
        {
            Type stateType = typeof(T);
            if (_states.TryGetValue(stateType, out var state))
            {
                if(state==_currentState)return;
                _currentState?.Exit();
                _currentState=state;
                _currentState.Enter();
                Debug.Log(stateType.Name + " entered");
            }
            else
            {
                //TODO
                //add register
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

