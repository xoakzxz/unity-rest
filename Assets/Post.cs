using System;
using System.ComponentModel;

[Serializable]
[Description ("posts")]
public class Post 
{
	public string userId;
	public int id;
	public string title;
	public string body;

	public Post (string userId, string title, string body)
	{
		this.userId = userId;
		this.title = title;
		this.body = body;
	}

	public override string ToString ()
	{
		return string.Format ("{0} - {1}:{2}\n{3}", title, userId, id, body);
	}
}
