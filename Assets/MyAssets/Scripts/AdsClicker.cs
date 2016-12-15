using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdsClicker : MonoBehaviour {

	public Image ProgressBar;
	public Image BackgroundImage;
	public Text CanvasText;
	public string next_scene;
	public AdsHandler adsHandler;

	public float speed;

	private bool isGazed;

	void Start () {
		isGazed = false;	
	}

	void Update () {
		if (isGazed) {
			Vector3 progress = ProgressBar.transform.localScale;
			if (progress.x >= 1.0f) {
				ClickAds ();
				isGazed = false;
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

	void ClickAds () {
		SceneManager.LoadScene (adsHandler.getNativeAd ().GetText ("NextScene"));
	}
}
