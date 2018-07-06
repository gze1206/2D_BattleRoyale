using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ScopeType { x2, x4, x8, x15 }
public class Scope : Item
{
    public ScopeType _type;

    private int[] _scopeSize = new int[4] { 2, 4, 8, 15 };
    private int _size;

    //인벤토리에 보관할 아이템 생성
    public void SetScope(ScopeType type)
    {
        _type = type;
        _size = _scopeSize[(int)type];
    }

    //획득시 범위 자동 변경
    public override void OnPickUp(Inventory target)
    {
        for (int i = 0; i < target.scopeList.Count; i++)
        {
            if (target.scopeList[i]._type == _type)
            {
                target.scopeList[i].SetCameraRange();
                return;
            }
           // else if (target.scopeList[i]._type > _type)
             //   target.scopeList.Insert(i--, new Scope(_type));
        }
    }

    //키메라 범위변경 시작
    public void SetCameraRange()
    {
        StartCoroutine(SetCameraSize());
    }

    //카메라 범위 변경
    IEnumerator SetCameraSize()
    {
        float elapsedTime = 0;
        while (elapsedTime < 2)
        {
            Camera.main.orthographicSize = Mathf.Lerp(3, _size, elapsedTime);
            yield return null;
        }
    }

}
