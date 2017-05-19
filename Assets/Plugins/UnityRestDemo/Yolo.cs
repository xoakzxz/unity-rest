using System;
using System.ComponentModel;

[Serializable]
[Description("yolo")]
public class Yolo {

    public string yolo1;
    public string yolo2;

    public Yolo(string yolo1, string yolo2)
    {
        this.yolo1 = yolo1;
        this.yolo2 = yolo2;
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}", yolo1, yolo2);
    }
}
