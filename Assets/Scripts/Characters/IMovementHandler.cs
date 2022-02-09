﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public interface IMovementHandler
    {
        void MoveHorizontal(int toMapX);
        void MoveVertical(int toMapY);
    }
}
