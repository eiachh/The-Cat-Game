using Assets.Scripts.Providers;
using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    class CrewMember : ICrewMember
    {
        private IMovementProvider movementProvider;
        private IMovementAnimatorAdapter movementAdapter;
        private CharacterConfiguration characterConfiguration;

        private Rigidbody2D rigidBody2D;

        public IMovementAnimatorAdapter MovementAdapter => movementAdapter;
        public ISkin Skin { get; set; }
        public CharacterConfiguration CharacterConfiguration => characterConfiguration;

        public CrewMember(IMovementAnimatorAdapter movementAdapter, ISkin skin, CharacterConfiguration configuration)
        {
            this.movementAdapter = movementAdapter;
            this.characterConfiguration = configuration;
            this.Skin = skin;

            //rigidBody2D = this.gameObject
        }

        public void MoveLeft()
        {
            MovementAdapter.MoveLeft();
        }

        public void MoveRight()
        {
            MovementAdapter.MoveRight();
        }

        public void MoveUp()
        {
            MovementAdapter.MoveUp();
        }

        public void MoveDown()
        {
            MovementAdapter.MoveDown();
        }
    }
}
