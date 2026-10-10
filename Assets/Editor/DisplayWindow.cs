using UnityEditor;

/// <summary>新しいウィンドウを開くだけ</summary>
public class DisplayWindow : EditorWindow
{
    private IWindow _displayW;

    public void Set(IWindow win) => _displayW = win;

    private void OnGUI()
    {
        if (_displayW != null)
            _displayW.Display();
    }
}
