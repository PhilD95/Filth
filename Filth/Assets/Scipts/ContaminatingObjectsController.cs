using UnityEngine;
using System;

public class ContaminatingObjectsController : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] ContaminationController contamination_controller;

    ContaminatingObjectsType contamination_type;
    
    public ContaminatingObjectsController(ContaminatingObjectsType l_c_type)
    {
        contamination_type = l_c_type;
    }

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        Vector3 playerpos = player.transform.position;
        Vector3 selfpos = transform.position;
        float distancetoplayer = (float)Math.Sqrt((Math.Pow(selfpos.y - playerpos.y, 2) + Math.Pow(selfpos.x - playerpos.x, 2)));
        if (distancetoplayer <= contamination_type.getRange()) {
            float decayfactor = (distancetoplayer / contamination_type.getRange()) * contamination_type.getDecay();
            contamination_controller.addContamination(contamination_type.getStrength() * decayfactor);
        }
	}
}
