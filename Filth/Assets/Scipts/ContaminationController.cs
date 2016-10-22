using UnityEngine;
using System.Collections;

public class ContaminationController: MonoBehaviour {

	private float contaminationValue = 0.0f;
	private int stepsSinceDebug = 0;

	public float ContaminationValue {
		get { return contaminationValue; }
		set { contaminationValue = value; }
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI()
	{
		if (Application.isEditor)  // or check the app debug flag
		{
			Rect debugTextRect = new Rect (new Vector2 (10, 10), new Vector2 (400, 40));
			GUI.Label(debugTextRect, "Contamination: " + contaminationValue);
		}
	}

	public void addContamination(float value) {
		contaminationValue += value;
	}
}
