using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public class StateMachine
    {
        /// <summary>
        /// State Machine Controller linked to this State Machine
        /// </summary>
        public readonly StateMachineController Controller;

        private State currentState;
        private bool isInitialized;

        /// <summary>
        /// Is this State Machine Initialized yet?
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                if (!isInitialized)
                {
                    ThrowNotInitializedWarning();
                }

                return isInitialized;
            }
            set
            {
                if (IsInitialized) return;
                isInitialized = value;
            }
        }

        /// <summary>
        /// Current State of this State Machine
        /// </summary>
        public State CurrentState
        {
            get => currentState;
            set
            {
                if (!IsInitialized) return;

                if (currentState != null)
                {
                    currentState.Exit();
                }

                currentState = value;

                currentState.Enter();
            }
        }

        public StateMachine(StateMachineController controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// Call this method to initialize a State Machine with its first State
        /// </summary>
        /// <param name="initialState">First state of the State Machine</param>
        public void Initialize(State initialState)
        {
            if (IsInitialized) return;

            IsInitialized = true;

            Debug.LogWarning("State Machine initialized.");

            CurrentState = initialState;
            CurrentState.Enter();
        }

        private void ThrowNotInitializedWarning() => Debug.LogWarning("State Machine not initialized.");
    }
}