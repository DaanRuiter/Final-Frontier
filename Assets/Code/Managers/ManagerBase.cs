﻿using UnityEngine;
using System.Collections;

namespace FinalFrontier
{
    namespace Managers
    {
        public abstract class ManagerBase : IEngineEvents
        {
            /// <summary>
            /// Called when starting the manager
            /// </summary>
            public abstract void OnStart();

            /// <summary>
            /// called each frame while the game is running
            /// </summary>
            public abstract void OnTick();

            /// <summary>
            /// called each frame while the game is not paused
            /// </summary>
            public abstract void OnUpdate();

            /// <summary>
            /// Called before the game is being saved
            /// </summary>
            public abstract void OnSave();

            /// <summary>
            /// Called before a game is loaded
            /// </summary>
            public abstract void OnLoad();

            /// <summary>
            /// Called before the game is exited
            /// </summary>
            public abstract void OnExit();
        }
    }
}