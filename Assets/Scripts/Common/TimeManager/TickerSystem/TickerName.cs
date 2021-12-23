using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.TimeManager.TickerSystem
{
    public class TickerName : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }
}