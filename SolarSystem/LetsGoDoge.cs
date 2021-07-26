using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsGoDoge : MonoBehaviour
{
    public GameObject Mars;
    public GameObject rocket;
    public float rocketSpeed = 5f;
    Vector3 originScale;
    bool isClick;

    private void Start()
    {
        originScale = transform.localScale;
    }

    private void Update()
    {
        LaunchRocket();
        Landing();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isClick = true;
            rocket.SetActive(true);
        }
    }

    public void OnClickDogeButton()
    {
        isClick = true;
        rocket.SetActive(true);
    }

    void LaunchRocket()
    {
        if (isClick)
        {   
            Vector3 dir = Mars.transform.position - transform.position;
            transform.position += dir.normalized * rocketSpeed * Time.deltaTime;
            transform.up = Vector3.Lerp(transform.up, dir, 0.5f);
            ScaleUpRocket();
        }
    }

    void ScaleUpRocket()
    {
        float maxScaleValue = 1f;
        Vector3 maxScale = Vector3.one * maxScaleValue;
        float scaleUpSpeed = rocketSpeed;
        Vector3 dir = Mars.transform.position - transform.position;
        float percent =  (scaleUpSpeed * rocketSpeed * maxScaleValue) / dir.magnitude;

        print("화성 거리 : " + dir.magnitude);

        if (dir.magnitude >= 0.4f)
        {
            //print("orignScale : " + originScale + " maxSCale : " + maxScale);
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, percent);
        }
        else if (dir.magnitude < 0.4f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originScale, percent);
        }
    }

    void Landing()
    {
        if (Vector3.Distance(transform.position, Mars.transform.position) <= 0.02f)
        {
            transform.position = Mars.transform.position;
            transform.SetParent(Mars.transform);
            isClick = false;
            gameObject.SetActive(false);
        }
    }
}
