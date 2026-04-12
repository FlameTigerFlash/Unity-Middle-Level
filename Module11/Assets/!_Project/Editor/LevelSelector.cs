using NUnit.Framework;
using System;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

[CustomEditor(typeof(GameManager))]
public class LevelSelector : Editor
{
    private string[] _settingsNames;
    private List<LevelSettings> _assets;
    private SerializedProperty _levelSettingsProp;


    private void OnEnable()
    {
        _levelSettingsProp = serializedObject.FindProperty("LevelSettings");

        string[] _settingsArray = AssetDatabase.FindAssets("t:LevelSettings");
        _settingsNames = new string[_settingsArray.Length];

        _assets = new List<LevelSettings>();
        for (int i = 0; i < _settingsArray.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(_settingsArray[i]);
            LevelSettings levelSettings = AssetDatabase.LoadAssetAtPath<LevelSettings>(path);
            _assets.Add(levelSettings);
            _settingsNames[i] = levelSettings.name;
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();

        LevelSettings current = (LevelSettings)_levelSettingsProp.objectReferenceValue;
        int currentIndex = _assets.IndexOf(current);
        if (currentIndex == -1) currentIndex = 0;

        int newIndex = EditorGUILayout.Popup("Select level settings", currentIndex, _settingsNames);
        if (newIndex != currentIndex)
        {
            _levelSettingsProp.objectReferenceValue = _assets[newIndex];
        }

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
