using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject[] DeckGroups;
    public GameObject BACKGROUND;
    public float DifferenceBetweenDG;

    public bool bTESTDECKGROUP = false;
    public GameObject goTESTDECKGROUP;
 

    float fDGPos_X = 0;
    float fBGPos_X = 50;
    int iBGCount = 0;

    void Awake () {
        C.lm = this;

    }


    public void NewDeckGroup()
    {
        int iRandomDeckNo = Random.Range(0, DeckGroups.Length);
        GameObject goTempDG = null;
        if (bTESTDECKGROUP)
        {
            goTempDG = (GameObject)Instantiate(goTESTDECKGROUP);
        }
        else
        {
            goTempDG = (GameObject)Instantiate(DeckGroups[iRandomDeckNo]);
        }
        fDGPos_X += DifferenceBetweenDG;
        goTempDG.transform.position = new Vector3(fDGPos_X, 0,0);
    }

    public void NewBackGround()
    {
        iBGCount++;
        if(iBGCount==2)
        { 
            fBGPos_X += 50;
            GameObject goTempBG = (GameObject)Instantiate(BACKGROUND);
            goTempBG.transform.position = new Vector3(fBGPos_X, 2, 30);
            iBGCount = 0;
        }
    }
}
