using System;

public class ChildCom : IDisposable
{
    private Action CDisposeAction;

    public void Set(Action act) => CDisposeAction += act;

    public void Dispose()
    {
        CDisposeAction.Invoke();
        CDisposeAction = null;
    }

    /// <summary>表示したいものを書く</summary>
    public virtual void CDisplay() { }
}
