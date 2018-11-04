using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPrefabs : MonoBehaviour {
    public GameObject guy1;
    public GameObject guy2;
    public GameObject currSkin;
    
    // Use this for initialization
    void Start () {
        currSkin = GameObject.Instantiate(guy1);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            
           Vector3 pos = new Vector3(currSkin.transform.position.x, currSkin.transform.position.y, 0);
            Destroy(currSkin);
            currSkin = GameObject.Instantiate(guy1);

            currSkin.transform.position = pos;


        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = new Vector3(currSkin.transform.position.x, currSkin.transform.position.y, 0);
            Destroy(currSkin);
            currSkin = GameObject.Instantiate(guy2);

            currSkin.transform.position = pos;
        }
    }
}
