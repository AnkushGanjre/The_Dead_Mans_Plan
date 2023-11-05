using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharChatData", menuName = "CharChatData/CharacterDataSO")]
public class CharChatDataSO : ScriptableObject
{
    // Specific for one Bot.
    public string botStatus;

    public int historyNum;
    public int botChatNum;
    public int playerOptionsNum;
    public int picListNum;

    public string BOTONE;
    public string BOTTWO;
    public string BOTTHIRD;
    public string BOTFOUR;
    public string BOTFIVE;
    public string BOTSIX;
    public string BOTSEVEN;
    public string BOTEIGHT;

    public List<string> chatHistory = new List<string>();
    public List<string> chatFromBot = new List<string>();
    public List<string> optionsToPlayer = new List<string>();
    public List<Sprite> pictureList = new List<Sprite>();
}
