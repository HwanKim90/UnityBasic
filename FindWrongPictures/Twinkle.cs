using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkle : MonoBehaviour
{
    public bool isLeft;
    public bool isRight;
    private MeshRenderer mr;
    private float moveSpeed = 5.0f;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
       
    }

    void Update() 
    {       
        StartCoroutine(TwinklePicture());
        if (Input.GetKey(KeyCode.Alpha1))
        {
            MoveCenter();
        }
    }

    void MoveCenter()
    {
        transform.position = Vector3.zero;
    }

    IEnumerator TwinklePicture()
    {   
        if (isLeft) 
        {
            mr.enabled = false;
            yield return new WaitForSeconds(1.2f);
            mr.enabled = true;
        }
        else 
        {
            mr.enabled = true;
            yield return new WaitForSeconds(1.2f);
            mr.enabled = false;
        }

    }
}
