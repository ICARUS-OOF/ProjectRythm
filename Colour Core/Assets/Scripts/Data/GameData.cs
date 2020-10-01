using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore.Data
{
    public static class GameData
    {
        public static List<string> completedLevels = new List<string>();
        public static bool HasCompletedLevel(string _levelName)
        {
            bool isCompleted = false;
            for (int i = 0; i < completedLevels.Count; i++)
            {
                if (completedLevels[i] == _levelName)
                {
                    isCompleted = true;
                }
            }
            return isCompleted;
        }
        public static void AddCompletedLevel(string _levelName)
        {
            completedLevels.Add(_levelName);
        }
    }
}
