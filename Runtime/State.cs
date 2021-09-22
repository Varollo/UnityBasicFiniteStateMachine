using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public abstract class State
    {
        /// <summary>
        /// State Machine linked to this State
        /// </summary>
        protected readonly StateMachine stateMachine;
        /// <summary>
        /// Time the State Machine entered this State
        /// </summary>
        protected float initialTime;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        /// <summary>
        /// Time passed since the State Machine entered this State
        /// </summary>
        public float Duration => Time.time - initialTime;

        /// <summary>
        /// Called by the State Machine when Entenring this State
        /// </summary>
        public virtual void Enter()
        {
            initialTime = Time.time;
        }

        /// <summary>
        /// Called every frame by the State Machine Controller
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Called every frame by the State Machine Controller after Update
        /// </summary>
        public virtual void LateUpdate()
        {

        }

        /// <summary>
        /// Called every fixed amount of frames by the State Machine Controller
        /// </summary>
        public virtual void FixedUpdate()
        {

        }

        /// <summary>
        /// Called by the State Machine when Exiting this State
        /// </summary>
        public virtual void Exit()
        {

        }
    }
}
