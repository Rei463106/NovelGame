using UnityEngine;
using UnityEngine.UI;

public class NovelUI : MonoBehaviour
{
    [Header("立ち絵")]
    [SerializeField] private Image _image;
    [Header("テキスト")]
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        NovelEvent._action += Appeare;
    }

    private void OnDisable()
    {
        NovelEvent._action -= Appeare;
    }

    private void Appeare(NovelSetting setting)
    {
        _image.sprite = setting.Sprite;
        _text.text = setting.Lines;
    }
}
