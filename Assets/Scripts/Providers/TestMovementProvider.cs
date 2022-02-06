using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Providers
{
    class TestMovementProvider : IMovementProvider
    {
        private int scale = 100;
        public void GoDown(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock)
        {
            movementAnimatorAdapter.MoveDown();
            rb.velocity = new Vector2(0, -1 * amountInBlock * scale);
        }

        public void GoLeft(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock)
        {
            movementAnimatorAdapter.MoveLeft();
            rb.velocity = new Vector2(-1 * amountInBlock * scale, 0);
        }

        public void GoRight(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock)
        {
            movementAnimatorAdapter.MoveRight();
            rb.velocity = new Vector2(1 * amountInBlock * scale, 0);
        }

        public void GoUp(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock)
        {
            movementAnimatorAdapter.MoveUp();
            rb.velocity = new Vector2(0, 1 * amountInBlock * scale);
        }
    }
}
