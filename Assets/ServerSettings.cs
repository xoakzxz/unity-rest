using UnityEngine;

[CreateAssetMenu]
public class ServerSettings : ScriptableObject
{
	[SerializeField]
	private string serverURL;
	[SerializeField]
	private int port = 80;

	public string ServerURL
	{
		get
		{
			return serverURL;
		}
	}

	public int Port
	{
		get
		{
			return port;
		}
	}

	public string URL
	{
		get
		{
			return string.Format ("{0}:{1}", ServerURL, Port);
		}
	}
}
