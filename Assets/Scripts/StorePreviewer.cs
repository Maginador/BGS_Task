using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePreviewer : MonoBehaviour
{
    private ProductSO currentSO;
    [SerializeField] Image hatSlot, chestSlot, rGloveSlot, lGloveSlot;



    public void ClearPreview()
    {

        hatSlot.sprite = null;
        hatSlot.enabled = false;

        chestSlot.sprite = null;
        chestSlot.enabled = false;

        rGloveSlot.sprite = null;
        rGloveSlot.enabled = false;

        lGloveSlot.sprite = null;
        lGloveSlot.enabled = false;
    }
    public void ShowPreview(ProductSO so)
    {
        ClearPreview();
        switch (so.category)
        {
            case ProductSO.Category.Hat:
                hatSlot.sprite = so.asset;
                hatSlot.enabled = true;
                break;
            case ProductSO.Category.Chest:
                chestSlot.sprite = so.asset;
                chestSlot.enabled = true;
                break;

            case ProductSO.Category.Glove:
                rGloveSlot.sprite = so.asset;
                rGloveSlot.enabled = true;
                lGloveSlot.sprite = so.asset;
                lGloveSlot.enabled = true;
                break;
        }
        currentSO = so;
    }

    public ProductSO GetCurrentProduct()
    {
        return currentSO;
    }
}
