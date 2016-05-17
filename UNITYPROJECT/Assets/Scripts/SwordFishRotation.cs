using UnityEngine;
using System.Collections;

public class SwordFishRotation : MonoBehaviour {

    public float fRotateSpeed;

    void Update () {

        transform.Rotate(new Vector3(fRotateSpeed,0,0)*Time.deltaTime);
	
	}
}
