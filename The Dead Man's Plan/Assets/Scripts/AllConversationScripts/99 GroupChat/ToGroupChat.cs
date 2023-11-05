using UnityEngine;

public class ToGroupChat : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.botStatus = "Offline";
        charDataSO.historyNum = 0;
        charDataSO.botChatNum = 0;
        charDataSO.playerOptionsNum = 0;
        charDataSO.chatHistory.Clear();
        charDataSO.chatFromBot.Clear();
        charDataSO.optionsToPlayer.Clear();
    }
    private void Start()
    {
        // 1
        charDataSO.optionsToPlayer.Add("Hello");
        charDataSO.optionsToPlayer.Add("Do I know you?");
        charDataSO.optionsToPlayer.Add("Yes I am");
        // 2
        charDataSO.optionsToPlayer.Add("How?");
        charDataSO.optionsToPlayer.Add("(Don't say anything)");
        charDataSO.optionsToPlayer.Add("Why me?");



    }

}
