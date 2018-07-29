using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour {
    [Header("gates")]
    public List<SlicerGate> gates = new List<SlicerGate>();

    [Header("Other Parts")]
    public SlicerLever lever;
    public SlicerKillZone killZone;


    private void Start()
    {
        lever.Initialize(this);
        killZone.Initialize(this);

    }

    public void OpenGate()
    {
        Debug.Log("Opening a Gate");

        int count = gates.Count;
        for (int i = 0; i < count; i++)
        {
            if (gates[i].active)
            {
                gates[i].Deactivate();
                break;
            }

        }
    }

    public void ResetGates()
    {
        int count = gates.Count;
        for (int i = 0; i < count; i++)
        {
            if (gates[i].active == false)
            {
                gates[i].Activate();
            }
        }
    }



    [System.Serializable]
    public class SlicerGate {
        public Collider2D gate;
        public bool active = true;

        public void Deactivate()
        {
            active = false;
            gate.enabled = false;
        }

        public void Activate()
        {
            active = true;
            gate.enabled = true;
        }
    }


}
