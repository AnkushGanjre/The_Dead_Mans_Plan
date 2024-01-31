using UnityEngine;

public class ToAjayShastri : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.botStatus = "Offline";
        charDataSO.historyNum = 0;
        charDataSO.botChatNum = 0;
        charDataSO.playerOptionsNum = 0;
        charDataSO.picListNum = 0;
        charDataSO.chatHistory.Clear();
        charDataSO.chatFromBot.Clear();
        charDataSO.optionsToPlayer.Clear();
        charDataSO.pictureList.Clear();
    }
    void Start()
    {
        //(Don't say anything)
        // 1
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Hello!");
        charDataSO.optionsToPlayer.Add("Do I know you?");
        charDataSO.optionsToPlayer.Add("Err... What?");
        // 2
        charDataSO.optionsToPlayer.Add("4");
        charDataSO.optionsToPlayer.Add("Sounds scary!");
        charDataSO.optionsToPlayer.Add("(Don't say anything)");
        charDataSO.optionsToPlayer.Add("A killer on loose!!");
        charDataSO.optionsToPlayer.Add("EMOJI3");
        // 3
        charDataSO.optionsToPlayer.Add("2");
        charDataSO.optionsToPlayer.Add("Is this a challenge?");
        charDataSO.optionsToPlayer.Add("You haven't met me!!");
        // 4
        charDataSO.optionsToPlayer.Add("2");
        charDataSO.optionsToPlayer.Add("Yes");
        charDataSO.optionsToPlayer.Add("EMOJI5");
    }
}
