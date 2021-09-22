using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public abstract class StateMachineController : MonoBehaviour
    {
        /// <summary>
        /// State Machine linked to this Controller
        /// </summary>
        public StateMachine StateMachine { get; private set; }

        /// <summary>
        /// Call this method to create a new State Machine.
        /// Should be called on Awake()
        /// </summary>
        protected virtual void CreateStateMachine() => StateMachine = new StateMachine(this);

        /// <summary>
        /// Call this method when you want to initialize the State Machine.
        /// Should be called on Start()
        /// </summary>
        /// <param name="initialState">First State of the State Machine</param>
        protected virtual void InitializeStateMachine(State initialState)
        {
            if (StateMachine == null)
            {
                Debug.LogError("Call 'CreateStateMachine()' method first.");
                enabled = false;
                return;
            }

            StateMachine.Initialize(initialState);
        }

        /// <summary>
        /// Called before Start().
        /// Used to create the State Machine.
        /// </summary>
        protected virtual void Awake()
        {
            CreateStateMachine();
        }

        /// <summary>
        /// Called every frame.
        /// Used to update the State Machine's Current State
        /// </summary>
        protected virtual void Update()
        {
            StateMachine.CurrentState.Update();
        }

        /// <summary>
        /// Called every frame after Update.
        /// Used to update the State Machine's Current State
        /// </summary>
        protected virtual void LateUpdate()
        {
            StateMachine.CurrentState.LateUpdate();
        }

        /// <summary>
        /// Called every fixed amount of time.
        /// Used to update the State Machine's Current State
        /// </summary>
        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentState.FixedUpdate();
        }
    }
}