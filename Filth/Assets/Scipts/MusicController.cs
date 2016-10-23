using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{

	[SerializeField] AudioMixer mixer;

	AudioMixerSnapshot[] mixerSnapshots;
	ContaminationController contaminationController;
	int lastContaminationLevel;

	void Start ()
	{
		// Get contamination controller
		GameObject gameCore = GameObject.FindWithTag("GameController");
		contaminationController = gameCore.GetComponent<ContaminationController>();

		// Set contaminationLevel to -1
		lastContaminationLevel = -1;

		// Get audio mixer groups
		mixerSnapshots = new AudioMixerSnapshot[12];
		for (int i = 0; i <= 10; ++i) {
			mixerSnapshots[i] = mixer.FindSnapshot("" + (i * 10));
		}
		mixerSnapshots[11] = mixer.FindSnapshot("tod");
	}

	void Update ()
	{
		int contamination = (int) contaminationController.ContaminationValue / 10;
		Debug.Assert(contamination >= 0);

		AudioMixerSnapshot snap = mixerSnapshots[Math.Min(contamination, 10)];
		if (lastContaminationLevel == -1)
			snap.TransitionTo(0.0f);
		else
			snap.TransitionTo(2.0f);

		lastContaminationLevel = contamination;
	}
}
