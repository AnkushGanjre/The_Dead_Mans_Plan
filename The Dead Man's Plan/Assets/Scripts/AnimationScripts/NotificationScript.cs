using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnExitNotification()
    {
        anim.SetBool("TimeOut", true);
    }
    public void OnEntryNotification()
    {
        anim.SetBool("TimeOut", false);
    }
}
