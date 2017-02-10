using UnityEngine;
using System.Collections;

public class AnalyticsHandler : MonoBehaviour {

	public string event_name;

	public float duration = 0.0f;

	void Update () {
		duration += Time.deltaTime;
	}

	public void SendEvent () {
		Firebase.Analytics.FirebaseAnalytics.LogEvent("travel_ads", event_name, duration);
	}
}
