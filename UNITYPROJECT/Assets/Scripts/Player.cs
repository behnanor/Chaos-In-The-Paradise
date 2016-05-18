using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float fRunMin;
    public float fRunMax;
    public float fJumpForce;
    private Rigidbody rigidbody;
    private float JumpCount=0;
    public Animator animator;

    private float fRunCur;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        fRunCur = fRunMin;
        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        Controls();
        transform.Translate(new Vector3(fRunCur,0,0)*Time.deltaTime);
        animator.SetFloat("RunSpeed", fRunCur/5);

      
    }
    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(fRunCur<fRunMax)
            {
                fRunCur += 0.05f;
            }
        }
    }
    void Controls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Crouch", true);
            if (JumpCount == 1)
            {
                Jump();
                JumpCount++;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            JumpCount++;
            if(JumpCount<=2)
                Jump();
        }
        if (Input.GetMouseButtonDown(1))
        {
          /*  animator.SetBool("Die", true);
            fRunCur = 0;
            fRunMax = -1;*/
        }
    }
    void Jump()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(new Vector3(0,1,0)*fJumpForce);
        if(JumpCount==1)
        { 
            animator.SetBool("Jump",true);
            animator.SetBool("Crouch", false);
        }
        if (JumpCount == 2)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Crouch", false);
        }
    }

    void OnTriggerEnter()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Deck")
        {
            animator.SetBool("Jump", false);
            JumpCount = 0;
            
        }
    }
}
