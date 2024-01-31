using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] private UnityEvent gamePlay;
    [SerializeField] private DataMangerSO dataMangerSO;
    [SerializeField] private TextMeshProUGUI displayText1;
    [SerializeField] private TextMeshProUGUI displayText2;

    [SerializeField] private GameObject phoneInterface;
    [SerializeField] private GameObject dialPad;
    [SerializeField] private GameObject incomingCall;
    [SerializeField] private GameObject OnGoingCall;
    [SerializeField] private GameObject bottomPanel;

    private AudioSource source;
    [SerializeField] private AudioClip clip;

    private bool numDialed;
    private int botCallingNum;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        botCallingNum = 0;
    }
    public void OnMakingCall()
    {
        incomingCall.SetActive(true);
        bottomPanel.SetActive(false);

        incomingCall.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.allBotCalls[botCallingNum];
        //Getting Dp
        for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
        {
            if (dataMangerSO.allBotCalls[botCallingNum] == dataMangerSO.allCharacters[a])
            {
                incomingCall.transform.GetChild(3).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
            }
        }
    }
    public void OnAcceptingVoiceCall()
    {
        incomingCall.SetActive(false);
        OnGoingCall.SetActive(true);
        OnGoingCall.transform.GetChild(2).GetComponent<Button>().interactable = false;
        
        source.PlayOneShot(clip);
        
        StartCoroutine(CallLength());
    }
    private IEnumerator CallLength()
    {

        yield return new WaitForSeconds(dataMangerSO.allCallsDuration[botCallingNum]);
        source.Stop();
        OnGoingCall.SetActive(false);
        bottomPanel.SetActive(true);
        OnGoingCall.transform.GetChild(2).GetComponent<Button>().interactable = true;
        dataMangerSO.currentActiveCharacterNum = 999;
        gamePlay.Invoke();
        botCallingNum++;
    }



    
    public void OnEndButtonPressed()
    {
        displayText1.text = string.Empty;
        numDialed = false;
        dialPad.SetActive(true);
        OnGoingCall.SetActive(false);
        incomingCall.SetActive(false);
        bottomPanel.SetActive(true);
    }
    public void OnCallNumDialed()
    {
        if (numDialed)
        {
            displayText2.text = displayText1.text;
            dialPad.SetActive(false);
            OnGoingCall.SetActive(true);
            bottomPanel.SetActive(false);
        }
    }
    public void OnEraseButtonPressed()
    {
        numDialed= false;
        displayText1.text = string.Empty;
    }
    public void onNum1pressed()
    {
        displayText1.text += "1";
        numDialed = true;
    }
    public void onNum2pressed()
    {
        displayText1.text += "2";
        numDialed = true;
    }
    public void onNum3pressed()
    {
        displayText1.text += "3";
        numDialed = true;
    }
    public void onNum4pressed()
    {
        displayText1.text += "4";
        numDialed = true;
    }
    public void onNum5pressed()
    {
        displayText1.text += "5";
        numDialed = true;
    }
    public void onNum6pressed()
    {
        displayText1.text += "6";
        numDialed = true;
    }
    public void onNum7pressed()
    {
        displayText1.text += "7";
        numDialed = true;
    }
    public void onNum8pressed()
    {
        displayText1.text += "8";
        numDialed = true;
    }
    public void onNum9pressed()
    {
        displayText1.text += "9";
        numDialed = true;
    }
    public void onNum0pressed()
    {
        displayText1.text += "0";
        numDialed = true;
    }
    public void onNumYpressed()
    {
        displayText1.text += "*";
        numDialed = true;
    }
    public void onNumZpressed()
    {
        displayText1.text += "#";
        numDialed = true;
    }
}
