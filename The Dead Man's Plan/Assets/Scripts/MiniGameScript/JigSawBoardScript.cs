using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JigSawBoardScript : MonoBehaviour, IDropHandler
{
    [SerializeField] private DataMangerSO dataMangerSO;
    [SerializeField] private Transform gameCanvas;
    [SerializeField] private Transform allPieces;
    [SerializeField] private Transform playBoard;
    [SerializeField] private GameObject completedImage;
    [SerializeField] private Transform t8ChatPeopleParent;
    [SerializeField] private Sprite unlock;

    private float oldAlpha = 0f;
    private float newAlpha = 1f;

    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.name == gameCanvas.GetChild(gameCanvas.childCount -1).name)
        {
            Transform lastChild = gameCanvas.GetChild(gameCanvas.childCount - 1);
            Destroy(lastChild.gameObject);

            Image targetImage = gameObject.GetComponent<Image>();
            Color currentColor = targetImage.color;
            currentColor.a = newAlpha;
            targetImage.color = currentColor;


            if (allPieces.childCount == 0)
            {
                //T8LockScript script = t8ChatPeopleParent.GetChild(0).GetComponent<T8LockScript>();
                //script.locked = false;
                //t8ChatPeopleParent.GetChild(0).GetChild(4).GetComponent<Image>().sprite = unlock;
                dataMangerSO.gameFinished = true;
                completedImage.SetActive(true);
                //AlphaChange();
            }
        }
    }
    private void AlphaChange()
    {
        foreach (Transform child in playBoard)
        {
            Image targetImage = child.GetComponent<Image>();
            Color currentColor = targetImage.color;
            currentColor.a = oldAlpha;
            targetImage.color = currentColor;
        }
    }
}
