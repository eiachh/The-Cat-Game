using Assets.Scripts.Map;
using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class BasicMovementHandler : MonoBehaviour, IMovementHandler
    {
        private IMovementAnimatorAdapter animationAdapter;
        private IMapPosition mapPosition; 

        private Vector3 destination = new Vector3();
        private bool isMoving;

        /// <summary>
        /// Sets the animation adapter.
        /// </summary>
        /// <param name="animationAdapter">The proper animation adapter.</param>
        public void SetMovementAnimatorAdapter(IMovementAnimatorAdapter animationAdapter)
        {
            this.animationAdapter = animationAdapter;
            mapPosition =  Factory.Instance.CreateMapPosition(transform);
        }

        public void MoveHorizontal(int toMapX)
        {
            isMoving = true;
            destination = new Vector3(toMapX, 0, 0);
            if(LocalToDestinationVector3().x < 0)
            {
                animationAdapter.MoveLeft();
                return;
            }

            animationAdapter.MoveRight();
        }

        public void MoveVertical(int toMapY)
        {
            isMoving = true;
            destination = new Vector3(0, toMapY, 0);
            if (LocalToDestinationVector3().y < 0)
            {
                animationAdapter.MoveDown();
                return;
            }

            animationAdapter.MoveUp();
        }

        private void Stop()
        {
            animationAdapter.Idle();
        }

        private void StopAndSnapToDestination()
        {
            transform.position = destination;
            isMoving = false;
            Stop();
        }

        private Vector3 LocalToDestinationVector3()
        {
            var currentSpot = new Vector3(mapPosition.X, mapPosition.Y, 0);
            return destination - currentSpot;
        }

        void FixedUpdate()
        {
            if (!isMoving)
                return;

            Vector3 localToDest = LocalToDestinationVector3();
            Vector3 normalizedDirection = localToDest.normalized;

            float distanceToDestination = localToDest.magnitude;
            float movingDistance = new Vector3(1 * Time.deltaTime * 2, 0, 0).magnitude;

            Vector3 actualMovement = normalizedDirection * movingDistance;            

            if(distanceToDestination < movingDistance)
            {
                StopAndSnapToDestination();
                return;
            }
            
            transform.Translate(actualMovement);
        }
    }
}
