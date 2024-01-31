using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllNewsScript : MonoBehaviour
{
    [SerializeField] private DataMangerSO dataMangerSO;

    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject newsPrefab;
    [SerializeField] private GameObject gameController;

    private void OnEnable()
    {
        newsRefresh();
    }
    public void newsRefresh()
    {
        for (int i = 0; i < dataMangerSO.newsIntroduced.Count; i++)
        {
            if (contentParent.childCount > i)
            {
                if (contentParent.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text == dataMangerSO.newsIntroduced[i])
                {
                    //DO Nothing
                }
            }
            else
            {
                //Chat not found, instantiating.
                GameObject A1 = Instantiate(newsPrefab, contentParent);
                A1.name = i.ToString();

                //Setting News heading & image
                //A1.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDP[i];
                A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.newsIntroduced[i];

                //Assigning function
                A1.GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnNewsOpen(A1.name));
            }
        }
    }
}
