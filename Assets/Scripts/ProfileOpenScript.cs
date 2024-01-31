using UnityEngine;
using UnityEngine.UI;

public class ProfileOpenScript : MonoBehaviour
{
    [SerializeField] private DataMangerSO dataMangerSO;
    [SerializeField] Sprite Dp;

    private void OnEnable()
    {
        CreatingProfile(dataMangerSO.chatIndex);
    }

    private void CreatingProfile(int botNum)
    {
        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = dataMangerSO.allCharDp[botNum];
    }
}
