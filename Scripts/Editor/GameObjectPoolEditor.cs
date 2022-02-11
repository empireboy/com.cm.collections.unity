using UnityEditor;

namespace CM.Collections.Editor
{
    [CustomEditor(typeof(GameObjectPool))]
    public class GameObjectPoolEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!EditorApplication.isPlaying)
                return;

            GameObjectPool gameObjectPool = (GameObjectPool)target;

            EditorGUILayout.LabelField("Objects in ObjectPool: " + gameObjectPool.Count, EditorStyles.boldLabel);
        }
    }
}