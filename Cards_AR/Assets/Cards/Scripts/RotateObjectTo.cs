using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateObjectTo : MonoBehaviour
{
    
    public GameObject objOne;
    public GameObject objTwo;
    private Vector3 targetPoit;

	// Update is called once per frame
	void Update ()
    {
        
        if (objOne != null && objTwo != null)
        {
            RotateObj(objOne,objTwo);
            RotateObj(objTwo,objOne);
        }
    }

    private void RotateObj(GameObject obj1,GameObject obj2){
            Vector3 target;
            target = new Vector3(obj2.transform.position.x,
                                     obj1.transform.position.y,
                                     obj2.transform.position.z);
            obj1.transform.LookAt(target);
    }
    
}
