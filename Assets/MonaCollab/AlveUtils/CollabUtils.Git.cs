#if UNITY_EDITOR

using UnityEngine;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace MonaCollab
{
    public static partial class CollabUtils
    {
        // Runs a git command using C# Process
        public static string Git(string gitCommand)
        {
            string output = "no-git";
            string errorOutput = "no-git";

            ProcessStartInfo processInfo = new ProcessStartInfo("git", @gitCommand)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            Process process = new Process
            {
                StartInfo = processInfo
            };

            try
            {
                process.Start();
            }
            catch (Exception e)
            {
                MessageWindow.Init(e.Message);
            }

            output = process.StandardOutput.ReadToEnd();
            errorOutput = process.StandardError.ReadToEnd();

            process.WaitForExit();
            process.Close();

            if (output.Contains("fatal") || output == "no-git" || output == "")
            {
                MessageWindow.Init("Command: git " + @gitCommand + " Failed\n" + output + errorOutput);
                return null;
            }

            if (errorOutput != "")
            {
                MessageWindow.Init("Git Error: " + errorOutput);
                return null;
            }

            return output;
        }
    }
}

#endif