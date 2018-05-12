using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class interactionHandler : MonoBehaviour, ITrackableEventHandler {

    #region PublicVar
    public GameObject[] ARTargets;
    public TrackableBehaviour[] TBs;
    public bool[] isAugmented;
    public float AnimTime;
    public GameObject objeAugmentend1;
    public GameObject objeAugmentend2;
    
    private GameObject currentPerson;
    private GameObject secundaryPerson;

    private RotateObjectTo rotateObjectComponent;

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

        for (int i = 0; i < ARTargets.Length; i++)
        {
            isAugmented[i] = false;
        }

        rotateObjectComponent = this.GetComponent<RotateObjectTo>();
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            for (int i = 0; i < ARTargets.Length; i++)
            {
                if (TBs[i].CurrentStatus == TrackableBehaviour.Status.DETECTED || 
                    TBs[i].CurrentStatus == TrackableBehaviour.Status.EXTENDED_TRACKED ||
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
                if (TBs[i].CurrentStatus != TrackableBehaviour.Status.DETECTED && 
                    TBs[i].CurrentStatus != TrackableBehaviour.Status.EXTENDED_TRACKED && 
                    TBs[i].CurrentStatus != TrackableBehaviour.Status.TRACKED)
                {
                    isAugmented[i] = false;
                }
            }
        }
        
    }

    void Update ()
    {
        if (isAugmented[0] && isAugmented[2]) // Viento
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <=2)
            {
                ARTargets[0].GetComponentInChildren<Animator>().SetBool("Attack", true);
                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Dead", true);
                ARTargets[0].GetComponentInChildren<Animator>().SetBool("Idle", false);
                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Idle", false);
                Debug.Log("Viento Gana");
            }
                else if (AnimTime >= 3)
                {
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Attack", false);
                }
        }
            else if (isAugmented[0] && isAugmented[8])// viento
            {
                AnimTime = AnimTime + Time.deltaTime;
                if (AnimTime >= 1 && AnimTime <= 2)
                {
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Attack", true);
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Dead", true);
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    Debug.Log("Viento Gana");

                    onDeadPerson(ARTargets[8]);
                }
                else if (AnimTime >= 3)
                {
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Attack", false);
                }
            }

                else if (isAugmented[0] && isAugmented[1])//viento
                {
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Friend", true);
                    ARTargets[1].GetComponentInChildren<Animator>().SetBool("Friend", true);
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    ARTargets[1].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    Debug.Log("Son cuates");
                }

                    else if (isAugmented[2] && isAugmented[6])//magia
                    {
                        AnimTime = AnimTime + Time.deltaTime;
                        if (AnimTime >= 1 && AnimTime <= 2)
                        {
                            ARTargets[2].GetComponentInChildren<Animator>().SetBool("Attack", true);
                            ARTargets[6].GetComponentInChildren<Animator>().SetBool("Dead", true);
                            ARTargets[2].GetComponentInChildren<Animator>().SetBool("Idle", false);
                            ARTargets[6].GetComponentInChildren<Animator>().SetBool("Idle", false);
                            Debug.Log("Magia Gana");
                        }
                            else if (AnimTime >= 3)
                            {
                                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Attack", false);
                            }
                    }

                        else if (isAugmented[2] && isAugmented[8])//magia
                        {
                            AnimTime = AnimTime + Time.deltaTime;
                            if (AnimTime >= 1 && AnimTime <= 2)
                            {
                                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Attack", true);
                                ARTargets[8].GetComponentInChildren<Animator>().SetBool("Dead", true);
                                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                ARTargets[8].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                Debug.Log("Magia Gana");
                            }
                                else if (AnimTime >= 3)
                                {
                                    ARTargets[2].GetComponentInChildren<Animator>().SetBool("Attack", false);
                                }
                        }

                            else if (isAugmented[2] && isAugmented[3])//magia
                            {
                                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Friend", true);
                                ARTargets[3].GetComponentInChildren<Animator>().SetBool("Friend", true);
                                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                ARTargets[3].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                Debug.Log("Son cuates");
                            }

        else if (isAugmented[4] && isAugmented[2])//Tierra
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 2)
            {
                ARTargets[4].GetComponentInChildren<Animator>().SetBool("Attack", true);
                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Dead", true);
                ARTargets[4].GetComponentInChildren<Animator>().SetBool("Idle", false);
                ARTargets[2].GetComponentInChildren<Animator>().SetBool("Idle", false);
                Debug.Log("Tierra Gana");
            }
                else if (AnimTime >= 3)
                {
                    ARTargets[4].GetComponentInChildren<Animator>().SetBool("Attack", false);
                }

        }
            else if (isAugmented[4] && isAugmented[0])// Tierra
            {
                AnimTime = AnimTime + Time.deltaTime;
                if (AnimTime >= 1 && AnimTime <= 2)
                {
                    ARTargets[4].GetComponentInChildren<Animator>().SetBool("Attack", true);
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Dead", true);
                    ARTargets[4].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    ARTargets[0].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    Debug.Log("Tierra Gana");
                }
                    else if (AnimTime >= 3)
                    {
                        ARTargets[4].GetComponentInChildren<Animator>().SetBool("Attack", false);
                    }
            }
                else if (isAugmented[4] && isAugmented[5])//Tierra
                {
                    ARTargets[4].GetComponentInChildren<Animator>().SetBool("Friend", true);
                    ARTargets[5].GetComponentInChildren<Animator>().SetBool("Friend", true);
                    ARTargets[4].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    ARTargets[5].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    Debug.Log("Son cuates");
                }
                    else if (isAugmented[6] && isAugmented[0])// Fuego
                    {
                        AnimTime = AnimTime + Time.deltaTime;
                        if (AnimTime >= 1 && AnimTime <= 2)
                        {
                            ARTargets[6].GetComponentInChildren<Animator>().SetBool("Attack", true);
                            ARTargets[0].GetComponentInChildren<Animator>().SetBool("Dead", true);
                            ARTargets[6].GetComponentInChildren<Animator>().SetBool("Idle", false);
                            ARTargets[0].GetComponentInChildren<Animator>().SetBool("Idle", false);
                            Debug.Log("Fuego Gana");
                        }
                            else if (AnimTime >= 3)
                            {
                                ARTargets[6].GetComponentInChildren<Animator>().SetBool("Attack", false);
                            }
                    }
                        else if (isAugmented[6] && isAugmented[4])// Fuego
                        {
                            AnimTime = AnimTime + Time.deltaTime;
                            if (AnimTime >= 1 && AnimTime <= 2)
                            {
                                ARTargets[6].GetComponentInChildren<Animator>().SetBool("Attack", true);
                                ARTargets[4].GetComponentInChildren<Animator>().SetBool("Dead", true);
                                ARTargets[6].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                ARTargets[4].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                Debug.Log("Fuego Gana");
                            }
                                else if (AnimTime >= 3)
                                {
                                    ARTargets[6].GetComponentInChildren<Animator>().SetBool("Attack", false);
                                }
                        }
                            else if (isAugmented[6] && isAugmented[7])// Fuego
                            {
                                ARTargets[6].GetComponentInChildren<Animator>().SetBool("Friend", true);
                                ARTargets[7].GetComponentInChildren<Animator>().SetBool("Friend", true);
                                ARTargets[6].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                ARTargets[7].GetComponentInChildren<Animator>().SetBool("Idle", false);
                                Debug.Log("Son cuates");
                            }

        else if (isAugmented[8] && isAugmented[4])// Agua
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 2)
            {
                ARTargets[8].GetComponentInChildren<Animator>().SetBool("Attack", true);
                ARTargets[4].GetComponentInChildren<Animator>().SetBool("Dead", true);
                ARTargets[8].GetComponentInChildren<Animator>().SetBool("Idle", false);
                ARTargets[4].GetComponentInChildren<Animator>().SetBool("Idle", false);
                Debug.Log("Agua Gana");
            }
                else if (AnimTime >= 3)
                {
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Attack", false);
                }

        }
            else if (isAugmented[8] && isAugmented[6])// Agua
            {
                AnimTime = AnimTime + Time.deltaTime;
                if (AnimTime >= 1 && AnimTime <= 2)
                {
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Attack", true);
                    ARTargets[6].GetComponentInChildren<Animator>().SetBool("Dead", true);
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    ARTargets[6].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    Debug.Log("Agua Gana");
                }
                    else if (AnimTime >= 3)
                    {
                        ARTargets[8].GetComponentInChildren<Animator>().SetBool("Attack", false);
                    }
            }
                else if (isAugmented[8] && isAugmented[9])// Agua
                {
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Friend", true);
                    ARTargets[9].GetComponentInChildren<Animator>().SetBool("Friend", true);
                    ARTargets[8].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    ARTargets[9].GetComponentInChildren<Animator>().SetBool("Idle", false);
                    Debug.Log("Son cuates");
                }

        else
        {
            for (int i = 0; i < ARTargets.Length; i++)
            {
                if (isAugmented[i] == false)
                {
                    ARTargets[i].GetComponentInChildren<Animator>().SetBool("Idle", true);
                    ARTargets[i].GetComponentInChildren<Animator>().SetBool("Friend", false);
                    ARTargets[i].GetComponentInChildren<Animator>().SetBool("Dead",false);
                    ARTargets[i].GetComponentInChildren<Animator>().SetBool("Attack", false);
                    AnimTime = 0;

                }
            }
            
        }
    }

    private void onDeadPerson(){
        currentPerson.GetComponentInChildren<Animator>().SetBool("Dead", true);
        currentPerson.GetComponentInChildren<Animator>().SetBool("Idle", false);
    }




/**  Metodos para manejar interaccion por medio de tags, independiente al arreglo
    private void InteractiveTwoObject(GameObject obj1, GameObject obj2){
        if(objeAugmentend1 == null || objeAugmentend2 == null){
            try
            {
                objeAugmentend1 = rotateObjectComponent.objOne;
                objeAugmentend2 = rotateObjectComponent.objTwo;
            }
            catch (UnityException e)
            {
                Debug.Log("dont find objs");
            }
        }
        else{
            valueCollision(objeAugmentend1.tag,objeAugmentend2.tag);
        }
    }

    private void valueCollision(string mytag, string otherTag)
    {
        if (mytag.Equals(otherTag))
        {//Ambos son iguales


        }
        else
        {
            switch (mytag)
            {
                case "fire":
                    if(otherTag.Equals("earth") || otherTag.Equals("wind"))
                    {
                        
                        
                    }
                    else if(otherTag.Equals("water")||otherTag.Equals("magic"))
                    {
                        
                        
                        
                    }
                    break;
                case "water":
                    if (otherTag.Equals("fire") || otherTag.Equals("earth"))
                    {
                        
                        
                    }
                    else if (otherTag.Equals("wind") || otherTag.Equals("magic"))
                    {
                        
                        
                        
                    }
                    break;
                case "earth":
                    if (otherTag.Equals("wind") || otherTag.Equals("magic"))
                    {
                        
                        
                    }
                    else if (otherTag.Equals("water") || otherTag.Equals("fire"))
                    {
                        
                        
                        
                    }
                    break;
                case "wind":
                    if (otherTag.Equals("water") || otherTag.Equals("magic"))
                    {
                        
                        
                    }
                    else if (otherTag.Equals("fire") || otherTag.Equals("earth"))
                    {
                        
                        
                        
                    }
                    break;
                case "magic":
                    if (otherTag.Equals("water") || otherTag.Equals("fire"))
                    {
                        
                        
                    }
                    else if (otherTag.Equals("earth") || otherTag.Equals("wind"))
                    {
                        
                        
                        
                    }
                    break;
                default:
                    break;
            }
        }
    }
    */
}
