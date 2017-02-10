using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GazeCanvasEvent : MonoBehaviour {

	public Image ProgressBar;
	public Image BackgroundImage;
	public Text CanvasText;
	public string next_scene;
	public AnalyticsHandler analyticsHandler;
	public bool enableDurationTracking = true;
	
	public float speed;

	private bool isGazed;

	void Start () {
		isGazed = false;	
	}
	
	void Update () {
		if (isGazed) {
			Vector3 progress = ProgressBar.transform.localScale;
			if (progress.x >= 1.0f) {
				MoveScene ();
			} else {
				progress.x += speed;
				ProgressBar.transform.localScale = progress;
			}
		}
	}

	public void startGaze () {
		isGazed = true;
	}

	public void endGaze () {
		isGazed = false;
		Vector3 progress = ProgressBar.transform.localScale;
		progress.x = 0;
		ProgressBar.transform.localScale = progress;
	}

	void MoveScene () {
		isGazed = false;
		if (enableDurationTracking) {
			Debug.Log (analyticsHandler.duration);
			analyticsHandler.SendEvent ();
		}
		SceneManager.LoadScene (next_scene);
	}
}
