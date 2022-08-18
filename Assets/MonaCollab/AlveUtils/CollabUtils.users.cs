#if UNITY_EDITOR

using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace MonaCollab
{
    public static partial class CollabUtils
    {
        // Find all the users in the project by searching in the root directory for folders with the prefix "0_USERNAME"
        public static List<string> GetUsers(bool keepPath = false)
        {
            List<string> users = new List<string>();
            string[] directories = System.IO.Directory.GetDirectories(Application.dataPath, "0_*", System.IO.SearchOption.AllDirectories);
            foreach (string directory in directories)
            {
                if (!keepPath)
                {
                    string user = directory.Replace(Application.dataPath, "").Replace("\\", "").Replace("/", "");
                    users.Add(user);
                }
                else
                {
                    users.Add(directory.Replace("/", "\\"));
                }
            }
            return users;
        }

        // Get's the first scene in the directory
        public static Scene GetUserScene(string user)
        {
            return EditorSceneManager.OpenScene(Application.dataPath + "/" + user + "/" + user + ".unity");
        }
    }
}

#endif