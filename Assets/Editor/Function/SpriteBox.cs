using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteBox : EditorWindow
{
    private Action<SpriteBox> DeleteAction;
    private string _name;
    private StateWindow _stateWindow;
    private List<Sprites> _spList = new();

    public List<Sprites> SPList => _spList;

    public string Name => _name;

    public void FirstSet(string name)
    {
        _name = name;
        //あらかじめ4種類だけは作る、CreateInstanceする？
    }

    public void AppearBox()
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);//()内を変更すれば、ボックスの見た目変えられそう

        if (GUILayout.Button("-"))
            DeleteMe();

        EditorGUILayout.TextField(_name);
        //ここに絵のまとまりを表示する

        if (GUILayout.Button("+"))
            ClickPlus();

        EditorGUILayout.EndVertical();
    }

    public void ClickPlus()
    {
        _stateWindow = GetWindow<StateWindow>();
        _stateWindow.StateCloseAction += AddState;
    }

    private void AddState(string state, Texture2D tex)//絵も！
    {
        //新しく箱作る！
        //Spritesが消された時それを受け取れるところを作る…。
        //マイナス押されたら消えるように登録する！(Spritesへの登録)
        _stateWindow.StateCloseAction -= AddState;
    }

    //以下、Spritesへの登録用
    private void Sender(Sprites sprites)
    {
        //登録解除書く
        _spList.Remove(sprites);
    }

    //以下、SpriteWindowからの登録＆実行用

    public void Register(string r, Action<SpriteBox> action)
    {
        if (r == "+")
            DeleteAction += action;
        else if (r == "-")
            DeleteAction -= action;
    }

    private void DeleteMe() => DeleteAction.Invoke(this);
}

public class StateWindow : EditorWindow
{
    private Texture2D _tex;
    private string _state;
    public Action<string, Texture2D> StateCloseAction;//絵も渡せるように

    private void OnGUI()
    {
        EditorGUILayout.LabelField("状態を入力してください");
        EditorGUILayout.LabelField("(後からでも変更できます)");
        _state = EditorGUILayout.TextField("State");

        if ((GUILayout.Button("…", GUILayout.Width(30))))
        {
            string path = EditorUtility.OpenFilePanel("画像を選択", "", "png,jpg,jpeg");

            if (!string.IsNullOrEmpty(path))
            {
                byte[] bytes = File.ReadAllBytes(path);

                _tex = new Texture2D(2, 2);
                _tex.LoadImage(bytes);
            }
        }

        if (GUILayout.Button("決定"))
        {
            StateCloseAction.Invoke(_state, _tex);
            Close();
        }
    }
}
