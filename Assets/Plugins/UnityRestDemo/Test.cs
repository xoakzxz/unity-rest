using UnityEngine;
using UnityRest;

public class Test : MonoBehaviour 
{
	private UnityRestManager api;

	private void Start ()
	{
		api = UnityRestManager.Instance;
	}

	private void Update () 
	{
        //Team
        if (Input.GetKeyDown(KeyCode.G))
            GetAll();
        if (Input.GetKeyDown(KeyCode.O))
            GetOne();
        if (Input.GetKeyDown(KeyCode.P))
            Post();

        //Yolo
        if (Input.GetKeyDown(KeyCode.Y))
            GetAllYolo();
        if (Input.GetKeyDown(KeyCode.U))
            PostYolo();

        //Player
        if (Input.GetKeyDown(KeyCode.Z))
            PlayerPost();
    }

    public void PlayerPost()
    {
        Player player = new Player("3", "rompqks");
        api.Post<Player>().WithBody(player).OnResult(LogOk).Send();
    }

	public void GetAll ()
	{
		api.Get<Team> ().OnResult<Team> (LogAll).Send ();
	}

    public void GetAllYolo()
    {
        api.Get<Yolo>().OnResult<Yolo>(LogAllYolo).Send();
    }

    public void GetOne ()
	{
		api.Get<Team> ().OnResult<Team> (Log).WithId ("1").Send ();
	}

    public void GetOneYolo()
    {
        api.Get<Yolo>().OnResult<Yolo>(LogYolo).WithId("1").Send();
    }

    private void Post()
    {
        Team team = new Team("1", "Hello", "world");
        api.Post<Team>().WithBody(team).OnResult(LogOk).Send();
    }

    private void PostYolo()
    {
        Yolo yolo = new Yolo("epa", "Bibiana");
        api.Post<Yolo>().WithBody(yolo).OnResult(LogOk).Send();
    }

    private void Log(Team post)
    {
        Debug.Log(post.title);
    }

    private void LogYolo(Yolo yolo)
    {
        Debug.Log(yolo.yolo1);
    }

    private void LogAll(Team[] posts)
    {
        foreach (Team post in posts)
            Log(post);
    }

    private void LogAllYolo(Yolo[] yolos)
    {
        foreach (Yolo yolo in yolos)
            LogYolo(yolo);
    }

    private void LogOk ()
	{
		Debug.Log ("Ok");
	}
}
