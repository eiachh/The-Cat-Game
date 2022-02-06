using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Providers
{
    public interface IMovementProvider
    {
        void GoRight(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock);
        void GoLeft(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock);
        void GoUp(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock);
        void GoDown(Rigidbody2D rb, IMovementAnimatorAdapter movementAnimatorAdapter, int amountInBlock);

    }
}
