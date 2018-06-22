using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Item {

    [SerializeField]
    private int limitHp = 10000;
    [SerializeField]
    private int hpAmount = 0;
    [SerializeField]
    private float limitTime = 3f;
    [SerializeField]
    private float waitTime = 3f;

    private IEnumerator waitToUse;

    public override void Use()
    {
        //TODO: 슬로우 적용
        waitToUse = WaitToUse();
        StartCoroutine(waitToUse);
    }

    //회복 취소
    public void Cancle()
    {
        StopCoroutine(waitToUse);
        //TODO: 슬로우 해제
    }

    //사용전 대기
    private IEnumerator WaitToUse()
    {
        float elapsedTime = 0f;
        while(elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            //TODO: 현재 진행정도 표시
            yield return null;
        }
        StartHeal();
    }

    //회복 시작
    protected virtual void StartHeal()
    {
        base.Use();
        StartCoroutine(HealUpdate());
        //TODO: 슬로우 해제
    }

    //회복이 종료된것을 알림
    protected virtual void EndHeal()
    {

    }

    //3초마다 힐
    private IEnumerator HealUpdate()
    {
        float elapsedTime = 0f;
        while(elapsedTime < limitTime)
        {
            //TODO: 플레이어 체력 회복
            yield return new WaitForSeconds(3f);
            elapsedTime += 3f;
        }
        EndHeal();
    }
}
