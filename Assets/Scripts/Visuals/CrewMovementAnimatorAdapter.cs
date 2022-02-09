using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Visuals
{

    public class CrewMovementAnimatorAdapter : IMovementAnimatorAdapter
    {
        private Animator animator { get; set; }

        public CrewMovementAnimatorAdapter(Animator animator)
        {
            this.animator = animator;
        }
        public void MoveDown()
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", 1);
        }

        public void MoveLeft()
        {
            animator.SetInteger("Horizontal", -1);
            animator.SetInteger("Vertical", 0);
        }

        public void MoveRight()
        {
            animator.SetInteger("Horizontal", 1);
            animator.SetInteger("Vertical", 0);
        }

        public void MoveUp()
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", -1);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Idle()
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", 0);
        }
    }
}
