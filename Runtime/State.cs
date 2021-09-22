using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public abstract class State
    {
        protected readonly StateMachine stateMachine;
        protected float initialTime;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public float Duration => Time.time - initialTime;

        public virtual void Enter()
        {
            initialTime = Time.time;
        }

        public virtual void Update()
        {

        }

        public virtual void LateUpdate()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}
