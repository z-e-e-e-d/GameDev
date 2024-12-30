using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerTrns;
    Transform camTrns;
    Vector3 temp;
    void Start()
    {
        camTrns = GetComponent<Transform>();
        playerTrns = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        temp = camTrns.position;
        temp.x = playerTrns.position.x;
        camTrns.position = temp;
    }
}
