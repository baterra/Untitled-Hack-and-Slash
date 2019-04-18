using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chgchgch : MonoBehaviour {
    public Animator myAnimator;
    public int k;
    public int kh;
    void Start () {
        myAnimator.Play("Test_Jump");

    }
	
	// Update is called once per frame
	void Update () {
        myAnimator.Play("Test_Jump");
    }
}
