using UnityEngine;
using System.Collections;

public class DeckGroup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        C.lm.NewDeckGroup();
        C.lm.NewBackGround();

    }

}
