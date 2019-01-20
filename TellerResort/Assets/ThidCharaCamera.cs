using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThidCharaCamera : MonoBehaviour {

    public Transform target;
    public float smooth = 5f;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smooth);
	}
}
