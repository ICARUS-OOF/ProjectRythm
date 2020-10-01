using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
namespace ColourCore.Editor
{
    public class MusicList : EditorWindow
    {
        private string[] musicList =
        {
            "Virtual Boy",
            "Insert No Coins"
        };

        [MenuItem("Window/Colour Core/Music List")]
        public static void DisplayWindow()
        {
            GetWindow<MusicList>("Music List");
        }

        private void OnGUI()
        {
            for (int i = 0; i < musicList.Length; i++)
            {
                GUILayout.Label(musicList[i], EditorStyles.label);
            }
        }
    }
}
#endif