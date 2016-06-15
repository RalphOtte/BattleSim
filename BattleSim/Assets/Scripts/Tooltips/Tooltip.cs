using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip;
    public GameController gameController;

    void Start()
    {
        
        gameController = FindObjectOfType<GameController >().GetComponent<GameController>();
        tooltip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.tooltipsEnabled)
            {
                tooltip.SetActive(true);
            }
        }

        if (gameController.playerTurn == 2)
        {
            if (gameController.p2.tooltipsEnabled)
            {
                tooltip.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
    }
}
