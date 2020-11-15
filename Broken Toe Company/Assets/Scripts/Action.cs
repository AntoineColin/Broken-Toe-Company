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
    protected bool used = true;

    Button btn;
    Image image;
    protected Text text;

    void Start()
    {
        btn = GetComponent<Button>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        text.text = ToString();
        CheckAvailability();
    }

    void CheckAvailability() {
        if (GameManager.INSTANCE.company.HasEnoughGold(priceMoney) && GameManager.INSTANCE.company.HasEnoughFood(priceFood))
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
        if(used) Destroy(gameObject);
    }

    protected abstract void Effect();
    protected abstract void EndEffect();
}
