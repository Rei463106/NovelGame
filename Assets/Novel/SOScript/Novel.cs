using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Novel", menuName = "Novel/Novel")]
public class Novel : ScriptableObject
{
    [Header("設定")]
    [SerializeField] private NovelSetting[] _novelSettings;

    public NovelSetting[] NovelSettings => _novelSettings;
}

[Serializable]
public class NovelSetting
{
    [Header("立ち絵")]
    [SerializeField] private Sprite _sprite;
    [Header("文章")]
    [SerializeField] private string _lines;

    public Sprite Sprite => _sprite;

    public string Lines => _lines;
}
