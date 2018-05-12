using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetFound : MonoBehaviour,ITrackableEventHandler {
    [SerializeField]
    private GameObject holder;
    
    private RotateObjectTo rotates;
    private TrackableBehaviour mTrackableBehaviour;
    private bool isOne = false;
    private bool isTwo = false;
    

    void Start()
    {
       holder = GameObject.Find("Holder");
        rotates = holder.GetComponent<RotateObjectTo>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play  when target is found
            Debug.Log("detected target");
            if(rotates.objOne == null){
                rotates.objOne = this.gameObject.transform.GetChild(0).gameObject;
                isOne = true;
                isTwo = false;
            }
            else if(rotates.objTwo == null){
                rotates.objTwo = this.gameObject.transform.GetChild(0).gameObject;
                isOne = false;
                isTwo = true;
            }
        }
        else
        {
            // Stop  when target is lost
            Debug.Log("target is miss");
            if(isOne){
                rotates.objOne = null;
            }
            else{
                rotates.objTwo = null;
            }
            
        }
    }

}
