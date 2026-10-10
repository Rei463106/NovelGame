using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpriteWindow : EditorWindow
{
    private NameWindow _nameWindow;
    private static List<SpriteBox> _spBList = new();

    /// <summary>シナリオに見せる用</summary>
    public static List<SpriteBox> SPBList => _spBList;

    [MenuItem("Novel/Settings/SetSprite")]
    private static void Open() => GetWindow<SpriteWindow>("SetSprite");//ウィンドウ名

    private void OnGUI()
    {
        if (GUILayout.Button("+"))
            ClickPlus();

        if (_spBList.Count > 0)
            foreach (var sprite in _spBList)
                sprite.AppearBox();
    }

    public void ClickPlus()
    {
        _nameWindow = GetWindow<NameWindow>("Name");
        _nameWindow.NameCloseAction += SetSpriteBox;
    }

    private void SetSpriteBox(string name)
    {
        var s = ScriptableObject.CreateInstance<SpriteBox>();

        _spBList.Add(s);
        s.FirstSet(name);
        s.Register("+", RegistOff);

        _nameWindow.NameCloseAction -= SetSpriteBox;
    }

    private void RegistOff(SpriteBox box)
    {
        box.Register("-", RegistOff);

        List<SpriteBox> removeBoxes = new();
        foreach (var sprite in _spBList)
            if (sprite != box)
                removeBoxes.Add(sprite);

        _spBList = removeBoxes;
    }
}

public class NameWindow : EditorWindow
{
    private string _name;

    public Action<string> NameCloseAction;

    private void OnGUI()
    {
        EditorGUILayout.LabelField("名前を入力してください");
        EditorGUILayout.LabelField("(後からでも変更できます)");
        _name = EditorGUILayout.TextField(_name);

        if (GUILayout.Button("決定"))
        {
            NameCloseAction?.Invoke(_name);
            Close();
        }
    }
}
