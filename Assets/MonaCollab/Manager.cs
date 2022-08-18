#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityToolbarExtender;


namespace MonaCollab
{
    [InitializeOnLoad]
    public static class Initial
    {
        static Initial()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            GUI.skin.button.fontSize = 12;
            GUI.skin.button.fixedHeight = 22;
            GUI.skin.button.border = new RectOffset(0, 0, 0, 0);
            GUI.skin.button.margin = new RectOffset(0, 0, 0, 0);
            GUI.skin.button.padding = new RectOffset(10, 10, 4, 4);
            GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            GUI.color = Color.white * 0.75f;
            GUI.contentColor = Color.white * 1.19f;

            if (GUILayout.Button(new GUIContent("↪️ Sync", "")))
            {
                MessageWindow.Init(CollabUtils.Git("add -A"));
                string date = DateTime.Now.ToString("dd-HH-mm-ss");
                MessageWindow.Init(CollabUtils.Git("commit -m \"Files Sync " + date + "\""));
                MessageWindow.Init(CollabUtils.Git("push"));
                MessageWindow.Init(CollabUtils.Git("pull"));
            }

            GUI.color = Color.white;
        }
    }
}
#endif