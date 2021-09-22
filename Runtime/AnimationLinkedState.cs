
using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    /// <summary>
    /// A State linked with a Animation
    /// </summary>
    public abstract class AnimationLinkedState : State
    {
        /// <summary>
        /// Type of transition you want to use in the animator
        /// </summary>
        public enum TransitionType
        {
            /// <summary>
            /// Plays the animation by the state name [animator.Play(animationStateName)]
            /// </summary>
            PlayByStateName,
            /// <summary>
            /// Plays the animation by setting a bool parameter [animator.SetBool(animationStateName, true)]
            /// </summary>
            BoolParameter
        }

        /// <summary>
        /// The name of the animation state or the bool parameter
        /// </summary>
        protected readonly string animationStateName;
        /// <summary>
        /// The type of transition to use in the animator
        /// </summary>
        protected readonly TransitionType transitionType;
        /// <summary>
        /// Animator linked to this State
        /// </summary>
        protected readonly Animator animator;

        public AnimationLinkedState(StateMachine stateMachine, string animationStateName, Animator animator, TransitionType transitionType) : base(stateMachine)
        {
            this.animator = animator;
            this.animationStateName = animationStateName;
            this.transitionType = transitionType;
        }

        public override void Enter()
        {
            base.Enter();
            PlayAnimation();
        }

        public override void Exit()
        {
            base.Exit();

            if (transitionType == TransitionType.BoolParameter)
            {
                animator.SetBool(animationStateName, false);
            }
        }

        /// <summary>
        /// Plays the animation considering the transition type
        /// </summary>
        protected virtual void PlayAnimation()
        {
            switch (transitionType)
            {
                case TransitionType.PlayByStateName:
                    animator.Play(animationStateName);
                    break;
                case TransitionType.BoolParameter:
                    animator.SetBool(animationStateName, true);
                    break;
            }
        }
    }
}