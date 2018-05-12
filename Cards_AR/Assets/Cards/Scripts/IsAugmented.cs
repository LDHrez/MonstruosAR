using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;



public class IsAugmented : MonoBehaviour, ITrackableEventHandler {

    #region PublicVar
    public GameObject[] ARTargets;	
    public TrackableBehaviour[] TBs;
    public bool[] isAugmented;
    #endregion


    void Start()
	{
		
        for(int i = 0; i< ARTargets.Length; i++)
	    {
		    TBs[i] = ARTargets[i].GetComponent<TrackableBehaviour>();
        }

		
        for (int i = 0; i < ARTargets.Length; i++)
		{
		   if (TBs[i])
           {
			 TBs[i].RegisterTrackableEventHandler(this);
           }
        }

		
        for(int i = 0; i < ARTargets.Length; i++)
		{
			isAugmented[i] = false;
	    }
    }

	
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
		
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
		    for (int i = 0; i < ARTargets.Length; i++)
			{
				
                if (TBs[i].CurrentStatus == TrackableBehaviour.Status.DETECTED || TBs[i].CurrentStatus == TrackableBehaviour.Status.EXTENDED_TRACKED || 
                    TBs[i].CurrentStatus == TrackableBehaviour.Status.TRACKED)
			    {
					isAugmented[i] = true;
				}
				
                else
				{
				    isAugmented[i] = false;
		        }
		    }
		}
		
        else
        {
			for (int i = 0; i < ARTargets.Length; i++)
	
		    {
	
			    if (TBs[i].CurrentStatus != TrackableBehaviour.Status.DETECTED && TBs[i].CurrentStatus != TrackableBehaviour.Status.EXTENDED_TRACKED && TBs[i].CurrentStatus != TrackableBehaviour.Status.TRACKED)
		
		        {
					
                    isAugmented[i] = false;
				}
		
	        }
	
	    }

	
    }

	
    void Update () {
		
        if(isAugmented[0]==false)
	    {
            ARTargets[0].GetComponentInChildren<Animator>().SetBool("Idle", true);
		}
        else if (isAugmented[1] == false)
        {
            ARTargets[1].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[2] == false)
        {
            ARTargets[2].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[3] == false)
        {
            ARTargets[3].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[4] == false)
        {
            ARTargets[4].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[5] == false)
        {
            ARTargets[5].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[6] == false)
        {
            ARTargets[6].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[7] == false)
        {
            ARTargets[7].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[8] == false)
        {
            ARTargets[8].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }
        else if (isAugmented[9] == false)
        {
            ARTargets[9].GetComponentInChildren<Animator>().SetBool("Idle", true);
        }




    }

}