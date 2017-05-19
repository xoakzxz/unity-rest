using System;
using System.ComponentModel;

[Serializable]
[Description("player")]
public class Player {

    public string id;
    public string name;

    public Player(string id ,string name)
    {
        this.id = id;
        this.name = name;
    }
}
