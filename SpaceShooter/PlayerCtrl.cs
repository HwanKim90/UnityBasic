#pragma warning disable IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim 
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
    public AnimationClip[] dies;
}

public class PlayerCtrl : MonoBehaviour
{   
    private float h;
    private float v;
    private float r;

    [Range(3.0f, 8.0f)]
    public float moveSpeed = 8.0f;
    public PlayerAnim playerAnim;

    private Animation anim;

    // awake는 스크립트가 비활성화되도 호출됨
    void Awake() 
    {   
       
    }

    void OnEnable() 
    {

    }
    
    // start 함수 코루틴으로 설정가능
    // IEnumerator Start()
    // {
    //     // logic a
    //     yield return new WaitForSeconds(0.1f);
    //     // logic b
    // }

    void Start() 
    {
        anim = this.gameObject.GetComponent<Animation>();
        anim.Play(playerAnim.idle.name);
    }

    // 화면을 랜더링 하는 주기
    /* 정규화 벡터, Normalized Vector, 단위벡터(Unit Vector)
        Vector3.foward = Vector3(0, 0, 1)
        Vector3.up     = Vector3(0, 1, 0)
        Vector3.right  = Vector3(1, 0, 0)

        Vector3.one    = Vector3(1, 1, 1)
        Vector3.zero   = Vector3(0, 0, 0)
    */

    void Update()
    {
        // Logic Something....
        //transform.position += new Vector3(0, 0, 0.1f);

        h = Input.GetAxis("Horizontal");    // -1.0f ~ 0.0f ~ +1.0f
        v = Input.GetAxis("Vertical");      // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");
        //v = Input.GetAxisRaw("")          // -1.0f ~ 0.0f ~ +1.0f

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * 100.0f * r);

        if (v >= 0.1f) 
        {
            // 전진 애니메이션으로 전환
            anim.CrossFade(playerAnim.runForward.name, 0.3f);
        }
        else if (v <= -0.1f)
        {
            // 후진
            anim.CrossFade(playerAnim.runBackward.name, 0.3f);
        }
        else if (h >= 0.1f) 
        {
            // 오른쪽 이동
            anim.CrossFade(playerAnim.runRight.name, 0.3f);
        }
        else if (h <= -0.1f)
        {
            // 왼쪽으로 이동
            anim.CrossFade(playerAnim.runLeft.name, 0.3f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }

    }

    // 물리엔진의 계산 주기
    void FixedUpdate()
    {   

    }

    void LateUpdate() 
    {
        // x 후처리 작업
    }

    
}