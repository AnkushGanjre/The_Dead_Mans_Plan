using UnityEngine;
using UnityEngine.EventSystems;

public class JigSawPiecesScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Transform topBarParent, headerParent, bgParent, boardParent, optionsParent;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private RectTransform[] targetRectTransforms; // Array of target RectTransforms

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root);
        for (int i = 0; i < boardParent.childCount; i++)
        {
            if (boardParent.GetChild(i).name == gameObject.name)
            {
                float width = boardParent.GetChild(i).transform.GetComponent<RectTransform>().rect.width;
                float height = boardParent.GetChild(i).transform.GetComponent<RectTransform>().rect.height;

                gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/ gameCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        foreach (RectTransform target in targetRectTransforms)
        {
            // Check if the pointer position is within the target RectTransform's rectangle
            if (RectTransformUtility.RectangleContainsScreenPoint(target, eventData.position, eventData.pressEventCamera))
            {
                if (target.name == topBarParent.name)
                {
                    transform.SetParent(optionsParent.GetChild(0).GetChild(0).GetChild(0));
                    gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
                }
                if (target.name == headerParent.name)
                {
                    transform.SetParent(optionsParent.GetChild(0).GetChild(0).GetChild(0));
                    gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
                }
                if (target.name == bgParent.name)
                {
                    //Eat 5 Star, Do Nothing.
                }
                if (target.name == boardParent.name)
                {
                    //Eat 5 Star, Do Nothing.
                }
                if (target.name == optionsParent.name)
                {
                    transform.SetParent(optionsParent.GetChild(0).GetChild(0).GetChild(0));
                    gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
                }
            }
        }
    }
}
