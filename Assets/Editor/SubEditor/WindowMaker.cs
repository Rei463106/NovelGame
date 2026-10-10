using System.Reflection;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 新しくウィンドウを作りたい場合に使用する
/// </summary>
/// <typeparam name="T"></typeparam>
public class WindowMaker<T> where T : class, IWindow
{
    private T _window;
    private DisplayWindow _displayWindow;
    public WindowMaker(T win) => _window = win;

    /// <summary>
    /// 第一引数でウィンドウの名前を入れる
    /// 引数の無いウィンドウ表示命令を第二引数で指示する
    /// </summary>
    /// <param name="title"></param>
    /// <param name="method"></param>
    public void SetWindow(string title, string method)
    {
        _displayWindow = ScriptableObject.CreateInstance<DisplayWindow>();
        _displayWindow.titleContent = new GUIContent(title);
        _displayWindow.Set(_window);
        MethodInfo m = typeof(EditorWindow).GetMethod(method);
        m?.Invoke(_displayWindow, null);
    }

    /// <summary>手動でウィンドウを閉じる時に呼ぶ</summary>
    public void DestroyWindow() => _displayWindow.Close();
}
