using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ScopeType { x1, x2, x4, x8, x15 }
public class Scope : Item
{
    public ScopeType _type;
    private int[] _scopeSize = new int[5] { 2, 3, 4, 5, 6 };

    //획득시 범위 자동 변경
    public override void OnPickUp(Inventory target)
    {
        base.OnPickUp(target);
        ScopeUi.scopeUi.OnGetScope(_type);
    }

    public void OnClick()
    {
        ScopeUi.scopeUi.SelectScope(_type);
    }

    //선택시 호출
    public void SelectScope(bool select)
    {
        if (select == false)
            StartCoroutine(SetUiSize(1));
        else
        {
            StartCoroutine(SetCameraSize());
            StartCoroutine(SetUiSize(2));
        }
    }

    //카메라 범위 변경
    IEnumerator SetCameraSize()
    {
        float elapsedTime = 0;
        float nowSize = Camera.main.orthographicSize;
        int _size = _scopeSize[(int)_type];

        while (elapsedTime <= 1)
        {
            elapsedTime += Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Lerp(nowSize, _size, Mathf.Min(elapsedTime,1));
            yield return null;
        }
    }

    //UI크기 변경
    IEnumerator SetUiSize(int size)
    {
        float elapsedTime = 0;
        float startSize = transform.localScale.x;

        while (elapsedTime <= 1)
        {
            elapsedTime += Time.deltaTime * 0.75f;
            float value = Mathf.Lerp(startSize, size, Mathf.Min(elapsedTime, 1));
            transform.localScale = new Vector3(value, value, 1);
            yield return null;
        }
    }
}
