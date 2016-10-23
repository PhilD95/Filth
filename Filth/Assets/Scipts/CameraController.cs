using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

	public float maxCamSize = 2.0f;
	public float minCamSize = 0.2f;
	public Vector2 camOffset = new Vector2(0.0f, 0.15f);
	public float animationSpeed = 1.0f;

	Camera cam;
	ContaminationController contaminationController;
	GameObject player;
	Material material;

	float factor = 1.0f;
	float timeShift = 0.0f;

	void Awake ()
	{
		material = new Material (Shader.Find ("Hidden/CameraShader"));
	}

	void Start ()
	{
		GameObject gameController = GameObject.FindWithTag("GameController");

		cam = GetComponent<Camera> ();
		contaminationController = gameController.GetComponent<ContaminationController>();
		player = GameObject.FindWithTag("Player");
	}

	void Update ()
	{
		// Update factor
		float contamination = contaminationController.ContaminationValue;
		factor = 1.0f - (contamination / 100.0f);

		if (factor < 0.0f)
			factor = 0.0f;
		else if (factor > 1.0f)
			factor = 1.0f;

		// Update timeShift
		timeShift += animationSpeed * Time.deltaTime;
		while (timeShift > 2 * Mathf.PI) {
			timeShift -= 2 * Mathf.PI;
		}
		
		// Update camera position
		float x = player.transform.position.x + camOffset.x;
		float y = player.transform.position.y + camOffset.y;
		float z = gameObject.transform.position.z;
		gameObject.transform.position = new Vector3(x, y, z);

		// Update camera size
		cam.orthographicSize = minCamSize + factor * (maxCamSize - minCamSize);
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Factor", factor);
		material.SetFloat("_TimeShift", timeShift);
		Graphics.Blit (source, destination, material);
	}
}
