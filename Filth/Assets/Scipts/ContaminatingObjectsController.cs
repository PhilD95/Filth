using UnityEngine;
using System;

public class ContaminatingObjectsController : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] GameObject gamecore;
    ContaminationController contamination_controller;

    public string name;
    public float strength;
    public float range;
    public float decay;

    // Use this for initialization
    void Start () {
        contamination_controller = gamecore.GetComponent<ContaminationController>();
	}

    // Update is called once per frame
    void Update() {
        Vector3 playerpos = player.transform.position;
        Vector3 selfpos = transform.position;
        float distancetoplayer = (float)Math.Sqrt((Math.Pow(selfpos.y - playerpos.y, 2) + Math.Pow(selfpos.x - playerpos.x, 2)));
        if (distancetoplayer <= range)
        {
            float decayfactor = (float)(decay * (1.0 - (distancetoplayer / range)));
            contamination_controller.addContamination(strength * decayfactor);
            Debug.Log("contaminate " + (strength * decayfactor));
        }
	}
}
