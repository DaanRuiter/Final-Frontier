﻿using System;

using UnityEngine;
using UnityEngine.UI;

using EndlessExpedition.Managers;

namespace EndlessExpedition
{
    namespace UI
    {
        class DebugInfoUI : MonoBehaviour
        {
            private int m_fps = 0;
            private double m_ms = 0;
            private float m_deltaTime = 0;
            private double m_timeToNextTick = 0;
            private GUISkin m_skin;
            private bool m_enabled = true;

            private void Start()
            {
                UpdateFramerate();
                UpdateSimTickTime();
                m_skin = ScriptableObject.CreateInstance<GUISkin>();
                m_skin.label.fontSize = 14;
                m_skin.label.alignment = TextAnchor.MiddleRight;
                m_skin.label.fixedWidth = Screen.width;
                m_skin.label.normal.textColor = Color.white;

                ManagerInstance.Get<InputManager>().AddEventListener(InputPressType.Up, KeyCode.F3, Toggle);
            }

            private void Update()
            {
                m_deltaTime += (Time.deltaTime - m_deltaTime) * 0.1f;
            }

            private void OnGUI()
            {
                if (!m_enabled)
                    return;

                GUI.skin = m_skin;
                if(m_fps > 60)
                    GUILayout.Label("<b>FPS:</b> <color=#00FF00>" + m_fps + "</color> " + m_ms + " ms");
                else
                    GUILayout.Label("<b>FPS:</b> <color=#FF0000>" + m_fps + "</color> " + m_ms + " ms");
                GUILayout.Label("<b>Time until next sim tick: </b>" + m_timeToNextTick + " ticks: " + ManagerInstance.Get<SimulationManager>().simulationTicksElapsed);
                GUILayout.Label("<b>Camera Position: </b>" + Camera.main.transform.position);
                GUILayout.Label("<b>Loaded Entities: </b>" + ManagerInstance.Get<EntityManager>().cachedEntityCount);
                GUILayout.Label("<b>Active Entities: </b>" + ManagerInstance.Get<EntityManager>().activeEntityCount);
                GUILayout.Label("<b>Time: </b>" + ManagerInstance.Get<SimulationManager>().timeAsString);
            }

            private void Toggle()
            {
                m_enabled = !m_enabled;

            }


            private void UpdateFramerate()
            {
                m_fps = (int)(1f / m_deltaTime);
                m_ms = Math.Round(m_deltaTime * 1000, 2, MidpointRounding.AwayFromZero);
                Invoke("UpdateFramerate", 1f);
            }

            private void UpdateSimTickTime()
            {
                m_timeToNextTick = Math.Round(ManagerInstance.Get<SimulationManager>().timeLeftUntilNextTick, 2, MidpointRounding.AwayFromZero);
                Invoke("UpdateSimTickTime", 0.05f);
            }
        }
    }
}
