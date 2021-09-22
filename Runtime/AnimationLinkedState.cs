
using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public abstract class AnimationLinkedState : State
    {
        public enum TransitionType
        {
            PlayByStateName,
            BoolParameter
        }

        protected readonly string animationStateName;
        protected readonly TransitionType transitionType;
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