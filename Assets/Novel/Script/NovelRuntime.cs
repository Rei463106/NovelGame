using System.Collections.Generic;

/// <summary>
/// ランタイム中の処理
/// </summary>
public class NovelRuntime
{
    private Queue<NovelSetting> _novelQueue = new Queue<NovelSetting>();
    private Novel _novel;
    private int _count = 0;

    public NovelRuntime(Novel novel)
    {
        _novel = novel;
        foreach (var r in _novel.NovelSettings)
        {
            _novelQueue.Enqueue(r);
        }
        _count = _novelQueue.Count;
    }

    public NovelSetting ReturnNovel()
    {
        _count--;
        if (_novelQueue.Count > 0)
            return _novelQueue.Dequeue();
        else
            return null;        
    }
}
