using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPicker : MonoBehaviour
{
    public Inventory inventory;

    public Text _infoText;
    public GameObject _infoObject;

    private Item _target = null;
    private IEnumerator _inputUpdate;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(new Vector3(-1, 0, 0));

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(new Vector3(1, 0, 0));

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(new Vector3(0, -1, 0));

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(new Vector3(0, 1, 0));
    }

    //아이템과 충돌시 정보창 활성화
    public void OnEnterItem(Item target)
    {
        if (_target != null)
            return;

        ShowInfo(true, target);
        _inputUpdate = InputUpdate();
        StartCoroutine(_inputUpdate);
    }

    //아이템 충돌 범위를 벗어났을떄 정보창 비활성화
    public void OnExitItem()
    {
        ShowInfo(false, null);
        StopCoroutine(_inputUpdate);
    }

    //아이템 정보 화면에 출력
    void ShowInfo(bool isShow, Item itemData)
    {
        if (itemData)
            _infoText.text = itemData.GetData();
        _target = itemData;
        _infoObject.SetActive(isShow);
    }

    //아이템 획득
    private void GetItem()
    {
        _target.OnPickUp(inventory);
        OnExitItem();
    }

    //F눌렀는지 확인
    IEnumerator InputUpdate()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.F))
                GetItem();
            yield return null;
        }
    }
}
