using UnityEngine;

public class AnimBotWritingScript : MonoBehaviour
{
    [SerializeField]private Animator anim;

    public void OnErasing()
    {
        anim.SetTrigger("isnotTrigger");
    }
    public void OnWriting()
    {
        anim.SetTrigger("isTrigger");
    }
}
