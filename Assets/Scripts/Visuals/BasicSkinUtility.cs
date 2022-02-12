using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Visuals
{
    class BasicSkinUtility : ISkin
    {
        private Sprite defaultSprite;
        private Sprite portrait;
        private AnimatorOverrideController animatorOverrideController;
        public BasicSkinUtility(Sprite defaultSprite, Sprite portrait, AnimatorController animatorController)
        {
            this.defaultSprite = defaultSprite;
            this.animatorOverrideController = new AnimatorOverrideController(animatorController);
            this.portrait = portrait;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="target"><inheritdoc/></param>
        public void ApplySkin(GameObject target)
        {
            ApplyDefaultSkin(target);
            ApplyAnimatorController(target);
        }

        public Sprite GetPortrait()
        {
            return portrait;
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(defaultSprite);
            UnityEngine.Object.Destroy(animatorOverrideController);
        }

        /// <summary>
        /// Applies the default sprite to the game object.
        /// </summary>
        /// <param name="target">The target object.</param>
        private void ApplyDefaultSkin(GameObject target)
        {
            var spriteRenderer = target.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = target.gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            }

            spriteRenderer.sprite = defaultSprite;
        }

        private void ApplyAnimatorController(GameObject target)
        {
            if (animatorOverrideController.runtimeAnimatorController == null)
            {
                return;
            }

            var animator = target.GetComponent<Animator>();
            if (animator == null)
            {
                animator = target.gameObject.AddComponent(typeof(Animator)) as Animator;
            }

            animator.runtimeAnimatorController = animatorOverrideController;
        }

        public void SetRenderLayer(GameObject target, RenderLayerCollection desiredLayer)
        {
            var spriteRenderer = target.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                return;
            }

            spriteRenderer.sortingLayerName = desiredLayer.ToString();
        }
    }
}
