using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public abstract class StateMachineController : MonoBehaviour
    {
        public StateMachine StateMachine { get; private set; }

        protected virtual void CreateStateMachine() => StateMachine = new StateMachine(this);

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

        protected virtual void Awake()
        {
            CreateStateMachine();
        }

        protected virtual void Update()
        {
            StateMachine.CurrentState.Update();
        }

        protected virtual void LateUpdate()
        {
            StateMachine.CurrentState.LateUpdate();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentState.FixedUpdate();
        }
    }
}