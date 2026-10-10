using System.Collections.Generic;
using System.Linq;

public class ParentCom : ChildCom
{
    private List<ChildCom> _cList = new();

    protected IReadOnlyList<ChildCom> CList => _cList;

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
