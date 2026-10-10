using System.Collections.Generic;
using System.Linq;
using UnityEditor;


public class MasterCom : EditorWindow
{
    private static List<ChildCom> _cList = new();

    protected static IReadOnlyList<ChildCom> CList => _cList;

    protected void PRegist(ChildCom c)
    {
        _cList.Add(c);
        c.Set(() =>
        {
            var temList = _cList.Where(x => x != c).ToList();
            _cList = temList;
        }
        );
    }
}
