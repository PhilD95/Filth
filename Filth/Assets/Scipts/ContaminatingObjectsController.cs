using UnityEngine;
using System;

public class ContaminatingObjectsController : MonoBehaviour {

    GameObject player;
    ContaminationController contamination_controller;

    public string name; // display name
    public float strength; // how many contaminant units pr cycle one loses at point blank range
    public float range; // the range of the contaminant
    public float decay; // the decay factor for the range: 0.0 means no reduction with range (strength is constant in entire range), 1.0 means proportional reduction with range

    // Use this for initialization
    void Start () {
		player = GameObject.FindWithTag("Player");

		GameObject gameController = GameObject.FindWithTag("GameController");
		contamination_controller = gameController.GetComponent<ContaminationController>();
	}

    // Update is called once per frame
    void Update() {
        Vector3 playerpos = player.transform.position;
        Vector3 selfpos = transform.position;
        float distancetoplayer = (float)Math.Sqrt((Math.Pow(selfpos.y - playerpos.y, 2) + Math.Pow(selfpos.x - playerpos.x, 2)));
        if (distancetoplayer <= range)
        {
            float decayfactor = (float)(decay * (1.0 - (distancetoplayer / range)));
            contamination_controller.addContamination(strength - (strength * decayfactor));
            Debug.Log("contaminate from " + name + ": " + (strength - (strength * decayfactor)));
        }
	}
}
