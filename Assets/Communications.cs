using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Communications : MonoBehaviour 
{
	[SerializeField]
	private ServerSettings settings;

	public void Get<T> (string id, Action<T> onFinished)
	{
		string service = Utils.GetDescription (typeof (T));
		string endpoint = string.Format ("{0}/{1}/{2}", settings.ServerURL, service, id);
		UnityWebRequest request = UnityWebRequest.Get (endpoint);	
		StartCoroutine (StartRequest (request, onFinished));
	}

	public void Post<T> (T record, int id, Action onFinished)
	{
		string service = Utils.GetDescription (typeof (T));
		string endpoint = string.Format ("{0}/{1}/{2}", settings.ServerURL, service, id);
		string postData = JsonUtility.ToJson (record);
		UnityWebRequest request = UnityWebRequest.Post (endpoint, postData);
		StartCoroutine (StartRequest (request, onFinished));
	}

	private IEnumerator StartRequest<T> (UnityWebRequest request, Action<T> onFinished)
	{
		Debug.Log ("Started request");
		yield return request.Send ();
		T response = JsonUtility.FromJson<T> (request.downloadHandler.text);
		onFinished (response);
	}

	private IEnumerator StartRequest (UnityWebRequest request, Action onFinished)
	{
		Debug.Log ("Started request");
		yield return request.Send ();
		onFinished ();
	}
}
