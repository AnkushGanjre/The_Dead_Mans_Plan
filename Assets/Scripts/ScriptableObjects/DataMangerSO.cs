using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataManger", menuName = "DataManger/DataMangerSO")]
public class DataMangerSO : ScriptableObject
{
    public int chatIndex;
    public int currentActiveCharacterNum;
    public string playerName;
    public string activeBot;

    public List<int> afterChapterStarts = new List<int>();
    public List<string> allCharacters = new List<string>();
    public List<Sprite> allCharDp = new List<Sprite>();

    // Normal Chat Data Storage.
    public List<string> chatsIntroduced = new List<string>();
    public List<string> allNrmlChats = new List<string>();
    public List<CharChatDataSO> nrmlChatSOList = new List<CharChatDataSO>();
    
    //T8 Chat Data Storage.
    public List<string> t8ChatIntroduced = new List<string>();
    public List<string> allT8Chats = new List<string>();
    public List<T8ChatDataSO> t8ChatSOList = new List<T8ChatDataSO>();

    //Phone Data Storage
    public List<string> allBotCalls = new List<string>();
    public List<int> allCallsDuration = new List<int>();

    //News Data Storage.
    public List<string> newsIntroduced = new List<string>();
    public List<string> allNews = new List<string>();
    public List<int> afterNewsEvent = new List<int>();

    public bool gameFinished = false;
}
