using UnityEditor;
using UnityEngine;

namespace ShootEmUp
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var targ = (GameManager)target;

            if (GUILayout.Button("Start game"))
            {
                targ.StartGame();
            }

            if (GUILayout.Button("Pause game"))
            {
                targ.PauseGame();
            }

            if (GUILayout.Button("Resume game"))
            {
                targ.ResumeGame();
            }

            if (GUILayout.Button("Finish game"))
            {
                targ.FinishGame();
            }
        }
    }
}