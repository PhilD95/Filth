using UnityEngine;
using System.Collections;

public class ContaminationController: MonoBehaviour {

	float contaminationValue = 0.0f;

	float ContaminationValue {
		get { return contaminationValue; }
		set { contaminationValue = value; }
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void addContamination(float value) {
		contaminationValue += value;
	}
}
