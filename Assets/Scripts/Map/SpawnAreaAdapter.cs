using Assets.Scripts.Providers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Map
{
    class SpawnAreaAdapter : MonoBehaviour
    {
        [Header("TopLeft")]
        public int tl_X;
        public int tl_Y;

        [Header("BottomRight")]
        public int br_X;
        public int br_Y;

        private ISpawnableArea selfSpawnArea;
        private void Start()
        {
            var topL = Factory.Instance.CreateMapPosition(tl_X, tl_Y);
            var botR = Factory.Instance.CreateMapPosition(br_X, br_Y);

            selfSpawnArea = Factory.Instance.MainMapManager.CreateSpawnArea(topL, botR, SpawnAreaType.Default);
        }
    }
}
