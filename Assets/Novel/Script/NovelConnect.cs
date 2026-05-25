using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class NovelConnect : MonoBehaviour
{
    [SerializeField] private Novel _novel;

    private NovelRuntime _runtime;

    private void Start()
    {
        _runtime = new NovelRuntime(_novel);
        var ct = this.GetCancellationTokenOnDestroy();
        Task(ct).Forget();
    }

    private async UniTask Task(CancellationToken ct)
    {
        var cm = _runtime.ReturnNovel();
        NovelEvent.ActionInvoke(cm);
        while (true)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Z), cancellationToken: ct);
            var c = _runtime.ReturnNovel();
            if (c != null)
                NovelEvent.ActionInvoke(c);
            else
                break;
        }
    }
}
