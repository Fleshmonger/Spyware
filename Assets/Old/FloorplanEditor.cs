using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Floorplan))]
public class FloorplanEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Floorplan floorplan = target as Floorplan;
        Floorplan floorplan = serializedObject.targetObject as Floorplan;

        floorplan.Width = EditorGUILayout.IntField("Width", floorplan.Width);
        floorplan.Length = EditorGUILayout.IntField("Length", floorplan.Length);

        /*
        Rect mapRect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(100));
        if (floorplan.GetTile(0, 0))
        {
            EditorGUI.DrawRect(mapRect, Color.blue);
        }
        else
        {
            EditorGUI.DrawRect(mapRect, Color.yellow);
        }
        */
    }

    /*
    public void OnSceneHGUI()
    {
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.keyDown:
                {
                    if (Event.current.keyCode == (KeyCode.A))
                    {
                        //(target as Floorplan).SetTile(0, 0, true);
                        e.Use();
                    }
                    break;
                }
        }
    }
    */
}
