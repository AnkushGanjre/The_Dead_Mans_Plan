using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "T8ChatData", menuName = "T8ChatData/T8ChatDataSO")]
public class T8ChatDataSO : ScriptableObject
{
    // Specific for one Bot.
    public int historyNum;
    public int chatNum;
    public int picListNum;

    public string BOTONE;
    public string BOTTWO;

    public List<string> chatHistory = new List<string>();
    public List<string> chatFromBot = new List<string>();
    public List<Sprite> pictureList = new List<Sprite>();
}
