using System.IO;
using UnityEditor;
using UnityEngine;

public class Story : EditorWindow
{
    private static string _text;

    public void Open() => GetWindow<Story>("Story");

    private void OnGUI()
    {
        if (GUILayout.Button("…", GUILayout.Width(30)))
            TextImport();

        if (_text != null)
        {
            string[] tArray = _text.Split('\n');
            for (int i = 0; i < tArray.Length; i++)
                EditorGUILayout.TextArea(tArray[i]);
        }
    }

    private void TextImport()
    {
        string path = EditorUtility.OpenFilePanel("ファイルを選択", "", "txt");

        if (!string.IsNullOrEmpty(path))
            _text = File.ReadAllText(path);
    }
}
