using Assets.Scripts.Characters;
using Assets.Scripts.Map;
using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;
using Assets.Scripts.Characters.Info;

namespace Assets.Scripts.Providers
{
    /// <summary>
    /// Default factory for the game.
    /// </summary>
    public class DefaultFactory : IFactory
    {
        private ISkinProvider skinProvider;
        private IMapManager mainMapManager;


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ILogger Logger => Debug.unityLogger;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISkinProvider SkinProvider => skinProvider;

        public IMapManager MainMapManager => mainMapManager;

        public DefaultFactory()
        {
            skinProvider = new BasicSkinProvider();
            mainMapManager = new MapManager();
        }

        public ISkin CreateSkin(Sprite defaultSprite, Sprite portrait, AnimatorController animatorController)
        {
            return new BasicSkinUtility(defaultSprite, portrait, animatorController);
        }

        public ICrewMember CreateCrewMember(CharacterConfiguration configuration, string skinName)
        {
            GameObject crewMemberGameObject = new GameObject(configuration.Name);

            ISkin selectedSkin = ApplySkin(skinName, crewMemberGameObject);
            IMovementHandler movementHandler = CreateMovementHandler(crewMemberGameObject);

            var createdMember = new CrewMember(crewMemberGameObject, movementHandler, selectedSkin, configuration);
            crewMemberGameObject.SetActive(false);
            return createdMember;
        }

        public IMovementAnimatorAdapter CreateMovementAnimatorAdapter(Animator animator, AnimatorAdapterType animatorAdapterType) =>
            animatorAdapterType switch
            {
                AnimatorAdapterType.CrewMovementAnimator => new CrewMovementAnimatorAdapter(animator),
                _ => null,
            };
        
        public IMovementHandler CreateMovementHandler(GameObject gameObject, IMovementAnimatorAdapter movementAnimatorAdapter)
        {
            var movementHandler = gameObject.AddComponent<BasicMovementHandler>();
            movementHandler.SetMovementAnimatorAdapter(movementAnimatorAdapter);

            return movementHandler;
        }

        public ICrewMember CreateRandomCrewMember()
        {
            var skinNameList = skinProvider.GetSkinNames();
            var skinAmount = skinNameList.Count();
            var selectedSkinNum = UnityEngine.Random.Range(0, skinAmount);
            var selectedName = skinNameList[selectedSkinNum];

            CharacterConfiguration charConfiguration = CharacterConfiguration.CreateRandomConfiguration();
            return CreateCrewMember(charConfiguration, selectedName);
        }

        public ICrew CreateCrew(IEnumerable<ICrewMember> members)
        {
            Crew crew = new Crew();
            foreach (var member in members)
            {
                crew.AddMember(member);
            }

            return crew;
        }

        /// <summary>
        /// Create a movement handler for the given game object.
        /// </summary>
        /// <param name="crewMemberGameObject">The object of the movement handler.</param>
        /// <returns>A movement handler.</returns>
        private IMovementHandler CreateMovementHandler(GameObject crewMemberGameObject)
        {
            var crewMemberAnimator = crewMemberGameObject.GetComponent<Animator>();
            if (crewMemberAnimator == null)
            {
                crewMemberAnimator = crewMemberGameObject.AddComponent<Animator>();
            }

            var animatorAdapter = CreateMovementAnimatorAdapter(crewMemberAnimator, AnimatorAdapterType.CrewMovementAnimator);
            var movementHandler = CreateMovementHandler(crewMemberGameObject, animatorAdapter);
            return movementHandler;
        }

        private ISkin ApplySkin(string skinName, GameObject crewMemberGameObject)
        {
            var selectedSkin = skinProvider.GetSkin(skinName);
            selectedSkin.ApplySkin(crewMemberGameObject);
            selectedSkin.SetRenderLayer(crewMemberGameObject, RenderLayerCollection.Player);
            return selectedSkin;
        }

        public IMapPosition CreateMapPosition(float x, float y)
        {
            return new TheoreticalMapPosition(x, y);
        }

        public IMapPosition CreateMapPosition(Transform transform)
        {
            return new TransformBasedMapPosition(transform);
        }
    }
}
