using System;
using TMPro;
using UnityEngine;

public class SysDateScript : MonoBehaviour
{
    private TextMeshProUGUI date;

    private void Awake()
    {
        date = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        DateTime msgTime = DateTime.Now;
        DayOfWeek dayOfWeek = System.DateTime.Now.DayOfWeek;
        string datex = LeadingZero(msgTime.Day);
        int month = System.DateTime.Now.Month;
        string monthString = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
        date.text = dayOfWeek + ", " + datex + " " + monthString;
    }

    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
