using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Action : MonoBehaviour
{
    public int priceMoney;
    public int priceFood;
    public bool removeWhenLeaving = true;
    public int nbUses = 1;
    protected bool available = true;

    protected Button btn;
    protected Image image;
    protected Text text;

    void Start()
    {
        btn = GetComponent<Button>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        Begin();
        text.text = ToString();
        CheckAvailability();
        GameManager.INSTANCE.onResourceChanged.AddListener(CheckAvailability);
        if (removeWhenLeaving) GameManager.INSTANCE.onEncounterChanged.AddListener(RemoveAction);
    }

    protected void CheckAvailability() {
        if (GameManager.INSTANCE.company.HasEnoughGold(priceMoney) && GameManager.INSTANCE.company.HasEnoughFood(priceFood) && available)
        {
            btn.interactable = true;
            btn.onClick.AddListener(Activate);
        }
        else
        {
            btn.interactable = false;
        }
    }

    void Activate()
    {
        Effect();
        btn.interactable = false;
        image.color = new Color(255, 216, 00);
        if (--nbUses == 0) RemoveAction();
    }

    protected void RemoveAction()
    {
        if(available) Destroy(gameObject);
    }

    protected abstract void Begin();
    protected abstract void Effect();
    protected abstract void EndEffect();
}
