
using System;

public static class NovelEvent
{
    public static Action<NovelSetting> _action;

    public static void ActionInvoke(NovelSetting n)
    {
        _action?.Invoke(n);
    }
}
