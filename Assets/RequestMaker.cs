using UnityEngine;
using UnityEngine.SceneManagement;

public class RequestMaker : MonoBehaviour 
{
	[SerializeField]
	private Communications communications;

	private void Update () 
	{
		if (Input.GetKeyDown (KeyCode.G))
			Get ();
		if (Input.GetKeyDown (KeyCode.P))
			Post ();
	}

	private void Get ()
	{
		communications.Get<Post> ("1", DebugResponse);
	}

	private void DebugResponse (Post response)
	{
		Debug.Log (response);
	}	

	private void Post ()
	{
		Post post = new Post ("1", "Hello", "world");
		communications.Post<Post> (post, 1, DebugResponse);
	}

	private void DebugResponse ()
	{
		SceneManager.LoadScene ("level");
		Debug.Log ("Finished");
	}
}
