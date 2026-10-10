using System;
using UnityEditor;
using UnityEngine;

/// <summary>絵を表示するための親クラス</summary>
public class Sprites : EditorWindow
{
    public Action<Sprites> DeleteAction;

    private void OnGUI()
    {
        //ボックスと押したら絵を変えられるところ
        EditorGUILayout.BeginVertical(GUI.skin.box);

        EditorGUILayout.EndVertical();
    }


    //以下、SpriteBoxを登録する用(でもこれ必要なの派生だけやな…)
    public void Register(string r, Action<Sprites> action)
    {
        if (r == "+")
            DeleteAction += action;
        else if (r == "-")
            DeleteAction -= action;
    }

    private void DeleteMe() => DeleteAction.Invoke(this);
}
