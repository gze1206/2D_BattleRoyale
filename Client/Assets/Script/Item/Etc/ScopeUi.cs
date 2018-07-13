using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScopeUi : MonoBehaviour
{
    public static ScopeUi scopeUi;

    private int enableCount = 1;
    private List<Scope> _scopeList = new List<Scope>();
    private List<ScopeType> _getList = new List<ScopeType>();
    
    private void Awake()
    {
        scopeUi = this;
        _getList.Add(ScopeType.x1);
        for (int i = 0; i < transform.childCount; i++)
            _scopeList.Add(transform.GetChild(i).GetComponent<Scope>());
    }

    public void SelectScope(ScopeType type)
    {
        for (int i = 0; i < enableCount; i++)
            _scopeList[i].SelectScope(_getList[i] == type);
    }

    public void OnGetScope(ScopeType type)
    {
        if(AddGetList(type))
        {
            _scopeList[enableCount++].gameObject.SetActive(true);
            SortScope(type);
        }
        SelectScope(type);
    }

    private bool AddGetList(ScopeType type)
    {
        for (int i = 0; i < _getList.Count; i++)
        {
            if (_getList[i] == type)
                return false;

            if (_getList[i] > type)
            {
                _getList.Insert(i, type);
                return true;
            }
        }

        _getList.Add(type);
        return true;
    }

    private void SortScope(ScopeType type)
    {
        float _posX = 0;
        for (int i = 1; i < _getList.Count; i++)
        {
            _scopeList[i]._type = _getList[i];
            _scopeList[i]._text.text = _getList[i].ToString();

            if (type == _getList[i] || type == _getList[i - 1])
                _scopeList[i].transform.localPosition = new Vector3(_posX + 76, 0, 0);
            else
                _scopeList[i].transform.localPosition = new Vector3(_posX + 38, 0, 0);

            _posX = _scopeList[i].transform.localPosition.x;
        }
        transform.localPosition = new Vector3(_posX * -0.5f, transform.localPosition.y, 0);
    }
}