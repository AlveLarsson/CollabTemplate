#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

namespace MonaCollab
{
    public class MessageWindow : EditorWindow
    {
        Vector2 Scroll;
        string Message;

        public static void Init(string Message)
        {
            if (Message == null || Message == "")
            {
                return;
            }
            MessageWindow window = (MessageWindow)MessageWindow.GetWindow(typeof(MessageWindow));

            window.Message = Message;
            window.titleContent = new GUIContent("Message");
            window.Show();
        }

        void OnGUI()
        {
            Scroll = GUILayout.BeginScrollView(Scroll, false, false);
            GUILayout.Label(Message);
            if (GUILayout.Button("Close"))
            {
                Close();
            }
            GUILayout.EndScrollView();
        }
    }
}
#endif