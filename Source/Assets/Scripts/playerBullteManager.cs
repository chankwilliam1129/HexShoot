using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

[System.Serializable]
public struct playerBulltePrefab
{
    public playerBullteMove prefab;
    public float damage;
    public float reloadSpeed;
    public float moveSpeed;
}

[CreateAssetMenu]
public class playerBullteManager : ScriptableObject
{
    public List<playerBulltePrefab> bullteList;
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(playerBullteManager), true)]
public class playerBullteManagerEditor : Editor
{
    SerializedProperty BullteList;
    ReorderableList list;

    private void OnEnable()
    {

        BullteList = serializedObject.FindProperty("bullteList");
        list = new ReorderableList(serializedObject, BullteList, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;
    }

    void DrawListItems(Rect rect, int index, bool isActive, bool isFocued)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

        EditorGUI.LabelField(new Rect(rect.x, rect.y, 45, EditorGUIUtility.singleLineHeight), "prefab");
        EditorGUI.PropertyField(
            new Rect(rect.x + 40, rect.y, 70, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("prefab"), GUIContent.none);

        EditorGUI.LabelField(new Rect(rect.x + 115, rect.y, 30, EditorGUIUtility.singleLineHeight), "Damage");
        EditorGUI.PropertyField(
            new Rect(rect.x + 150, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("damage"), GUIContent.none);

        EditorGUI.LabelField(new Rect(rect.x + 185, rect.y, 30, EditorGUIUtility.singleLineHeight), "reloadSpeed");
        EditorGUI.PropertyField(
            new Rect(rect.x + 215, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("reloadSpeed"), GUIContent.none) ;

        EditorGUI.LabelField(new Rect(rect.x + 250, rect.y, 30, EditorGUIUtility.singleLineHeight), "moveSpeed");
        EditorGUI.PropertyField(
            new Rect(rect.x + 280, rect.y, 30, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("moveSpeed"), GUIContent.none);
    }

    void DrawHeader(Rect rect)
    {
        string name = "BullteList";
        EditorGUI.LabelField(rect, name);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();

    }
}
#endif