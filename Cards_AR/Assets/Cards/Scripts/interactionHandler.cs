using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class interactionHandler : MonoBehaviour, ITrackableEventHandler
{

    #region PublicVar
    public GameObject[] ARTargets;
    public TrackableBehaviour[] TBs;
    public bool[] isAugmented;
    public float AnimTime;
    public GameObject objeAugmentend1;
    public GameObject objeAugmentend2;

    private GameObject personLosser;
    private GameObject personWinner;

    private RotateObjectTo rotateObjectComponent;
    private bool isFight;

    #endregion

    void Start()
    {
        for (int i = 0; i < ARTargets.Length; i++)
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

    void Update()
    {
        if (isAugmented[0] && isAugmented[2]) // Viento vs magic
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[2];
                personWinner = ARTargets[0];
                
                Invoke("onAttackPerson", 1);
                Debug.Log("Viento Gana");

            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }
        else if (isAugmented[0] && isAugmented[8])// viento vs water
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[8];
                personWinner = ARTargets[0];
                
                Debug.Log("Viento Gana");

                Invoke("onAttackPerson",1);
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }

        else if (isAugmented[0] && isAugmented[1])//viento vs viento
        {
            personWinner = ARTargets[0];
            personLosser = ARTargets[1];
            Invoke("onSeeFriend",1);
            Debug.Log("Son cuates");
        }

        else if (isAugmented[2] && isAugmented[6])//magic vs fire
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[6];
                personWinner = ARTargets[2];
                Invoke("onAttackPerson",1);
                Debug.Log("Magia Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }

        else if (isAugmented[2] && isAugmented[8])//magic vs water
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[8];
                personWinner = ARTargets[2];
                Invoke("onAttackPerson",1);
                
                Debug.Log("Magia Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }

        else if (isAugmented[2] && isAugmented[3])//magic vs magic
        {
            personWinner = ARTargets[2];
            personLosser = ARTargets[3];
            Invoke("onSeeFriend",1);
            Debug.Log("Son cuates");
        }

        else if (isAugmented[4] && isAugmented[2])//Tierra vs magic
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[2];
                personWinner = ARTargets[4];
                Invoke("onAttackPerson",1);
                Debug.Log("Tierra Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }

        }
        else if (isAugmented[4] && isAugmented[0])// Tierra vs wind
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[0];
                personWinner = ARTargets[4];
                Invoke("onAttackPerson",1);
                
                Debug.Log("Tierra Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }
        else if (isAugmented[4] && isAugmented[5])//Tierra vs tierra
        {
            personLosser = ARTargets[5];
            personWinner = ARTargets[4];
            Invoke("onSeeFriend",1);
            Debug.Log("Son cuates");
        }
        else if (isAugmented[6] && isAugmented[0])// Fuego vs magic
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[0];
                personWinner = ARTargets[6];
                Invoke("onAttackPerson",1);
                Debug.Log("Fuego Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }
        else if (isAugmented[6] && isAugmented[4])// Fuego vs earth
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[4];
                personWinner = ARTargets[6];
                Invoke("onAttackPerson",1);
                
                Debug.Log("Fuego Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }
        else if (isAugmented[6] && isAugmented[7])// Fuego vs fuego
        {
            personLosser = ARTargets[6];
            personWinner = ARTargets[7];
            Invoke("onSeeFriend",1);
            Debug.Log("Son cuates");
        }

        else if (isAugmented[8] && isAugmented[4])// Agua vs earth
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[4];
                personWinner = ARTargets[8];
                Invoke("onAttackPerson",1);
                Debug.Log("Agua Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }

        }
        else if (isAugmented[8] && isAugmented[6])// Agua vs fire
        {
            AnimTime = AnimTime + Time.deltaTime;
            if (AnimTime >= 1 && AnimTime <= 4)
            {
                personLosser = ARTargets[6];
                personWinner = ARTargets[8];
                Invoke("onAttackPerson",1);
                Debug.Log("Agua Gana");
            }
            else if (AnimTime >= 5)
            {
                Invoke("onDeadPerson",0.1f);
            }
        }
        else if (isAugmented[8] && isAugmented[9])// Agua vs agua
        {
            personLosser = ARTargets[8];
            personWinner = ARTargets[9];
            Invoke("onSeeFriend",1);
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
                    ARTargets[i].GetComponentInChildren<Animator>().SetBool("Dead", false);
                    ARTargets[i].GetComponentInChildren<Animator>().SetBool("Attack", false);
                    AnimTime = 0;

                }
            }

        }
    }

    private void onDeadPerson()
    {
        personLosser.GetComponentInChildren<Animator>().SetBool("Idle", false);
        personLosser.GetComponentInChildren<Animator>().SetBool("Dead", true);
        personWinner.GetComponentInChildren<Animator>().SetBool("Attack", false);
        personWinner.GetComponentInChildren<Animator>().SetBool("Idle", true);
    }

    private void onAttackPerson()
    {
        personWinner.GetComponentInChildren<Animator>().SetBool("Idle", false);
        personWinner.GetComponentInChildren<Animator>().SetBool("Attack", true);
    }

    private void onSeeFriend()
    {
        personLosser.GetComponentInChildren<Animator>().SetBool("Idle", false);
        personWinner.GetComponentInChildren<Animator>().SetBool("Idle", false);
        personWinner.GetComponentInChildren<Animator>().SetBool("Friend", true);
        personLosser.GetComponentInChildren<Animator>().SetBool("Friend", true);
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
