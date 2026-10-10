using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StoryWindow : MasterCom
{
    private StoryBox _doubleBox;


    public static IReadOnlyList<StoryBox> StoryBoxes()
    {
        if (!CList.All(x => x is StoryBox))

            throw new InvalidConversionException("CListにStoryBox以外の要素が含まれます");

        return CList.Cast<StoryBox>().ToList();
    }

    [MenuItem("Novel/Settings/MakeNovel")]
    private static void Open() => GetWindow<StoryWindow>("MakeNovel");

    private void OnGUI()
    {
        GUILayout.Label("物語を作成しよう", EditorStyles.boldLabel);

        if (GUILayout.Button("+", GUILayout.Width(30)))
            PRegist(new StoryBox());

        if (StoryBoxes().Count > 0)
            for (int i = 0; i < StoryBoxes().Count; i++)
                StoryBoxes()[i].CDisplay();




        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            foreach (var s in StoryBoxes())
            {
                if (s.MyRect.Contains(Event.current.mousePosition))
                {
                    if (Event.current.clickCount == 1)
                        s.ClickWindow();
                    if (Event.current.clickCount == 2)
                    {
                        s.ChangeEdit(true);
                        _doubleBox = s;
                    }
                }
            }
        }

        if (_doubleBox != null)
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && !_doubleBox.MyRect.Contains(Event.current.mousePosition) ||
                Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
            {
                _doubleBox.ChangeEdit(false);
                _doubleBox = null;
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log($"Destroy: {GetInstanceID()}");
    }
}