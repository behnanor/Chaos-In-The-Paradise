using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform tFollow;

    private Vector3 v3Diff;
    private float _y;

	// Use this for initialization
	void Start () {

        v3Diff = transform.position - tFollow.position;
        _y = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = v3Diff + tFollow.position;
        transform.position = new Vector3(transform.position.x, _y, transform.position.z);
	
	}
}
