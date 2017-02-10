using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdsRequest : MonoBehaviour {

	public Image ProgressBar;
	public Image BackgroundImage;
	public Text CanvasText;
	public AdsHandler adsHandler;

	public float speed;
	private bool isGazed;

	void Start () {
		isGazed = false;	
	}
	
	void Update () {
		if (isGazed) {
			Vector3 progress = ProgressBar.transform.localScale;
			if (progress.x >= 0.98f) {
				adsHandler.RequestAd ();
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


}
