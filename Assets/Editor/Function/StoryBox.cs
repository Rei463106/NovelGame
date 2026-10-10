using UnityEditor;
using UnityEngine;

public class StoryBox : ChildCom
{
    private GUIStyle _storyBGC;
    




    private Story _story;
    private Rect _myRect;
    private string _myStoryName;
    private string _editName = "New Story";
    private bool _isEdit;
    private bool _isOnce;

    public Rect MyRect => _myRect;
    public bool IsEdit => _isEdit;

    /// <summary>
    /// Instantiate的なもの
    /// </summary>
    /// <returns></returns>
    public void MakeBox(GUIStyle style)
    {
        _myRect = GUILayoutUtility.GetRect(GUIContent.none, GUI.skin.box, GUILayout.ExpandWidth(true), GUILayout.Height(20));
        GUI.Box(_myRect, GUIContent.none, style);

        if (_isEdit)
            _editName = EditorGUI.TextField(_myRect, _editName);
        else
        {
            _myStoryName = _editName;
            EditorGUI.LabelField(_myRect, _myStoryName);
        }
    }//なるべく同じ機能は一つに集約する

    public void ClickWindow()
    {
        _story = ScriptableObject.CreateInstance<Story>();
        _story.ShowModalUtility();
    }

    public void ChangeEdit(bool edit)
    {
        if (edit)
            _editName = _myStoryName;

        _isEdit = edit;
    }

    public override void CDisplay()
    {
        //GUIはGUIの中で初期化する、コンストラクターの方が良い…？？
        _storyBGC = new GUIStyle(GUI.skin.box);
        _storyBGC.normal.background = TextureWareHouse.MakeTexture(1, 1, Color.gray);
        throw new System.NotImplementedException();
    }
}
