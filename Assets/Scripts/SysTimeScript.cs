using System;
using TMPro;
using UnityEngine;

public class SysTimeScript : MonoBehaviour
{
    private TextMeshProUGUI time;

    private void Awake()
    {
        time = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        time.text = hour + "\n" + minute;
    }
    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
