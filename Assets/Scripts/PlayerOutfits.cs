using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutfits : MonoBehaviour
{
    private ProductSO _hat, _chest, _glove;
    private float _hatSize = .32f, _chestSize = .32f, _gloveSize = .25f;
    [SerializeField] SpriteRenderer hatRenderer, chestRenderer, gloveLRenderer, gloveRRenderer;

    public void SetOutfit(ProductSO so)
    {
        switch (so.category)
        {
            case ProductSO.Category.Hat:
                SetHat(so);
                break;

            case ProductSO.Category.Chest:
                SetChest(so);
                break;

            case ProductSO.Category.Glove:
                SetGlove(so);
                break;
        }
    }
    public void SetHat(ProductSO hat)
    {
        _hat = hat;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (_hat) hatRenderer.sprite = _hat.asset;
        hatRenderer.size = new Vector2(_hatSize, _hatSize);
        if (hatRenderer.sprite == null) hatRenderer.enabled = false;
        else hatRenderer.enabled = true;

        if (_chest) chestRenderer.sprite = _chest.asset;
        chestRenderer.size = new Vector2(_chestSize, _chestSize);

        if (chestRenderer.sprite == null) chestRenderer.enabled = false;
        else chestRenderer.enabled = true;


        if (_glove) gloveLRenderer.sprite = _glove.asset;
        gloveLRenderer.size = new Vector2(_gloveSize, _gloveSize);

        if (gloveLRenderer.sprite == null) gloveLRenderer.enabled = false;
        else gloveLRenderer.enabled = true;

        if (_glove) gloveRRenderer.sprite = _glove.asset;
        gloveRRenderer.size = new Vector2(_gloveSize, _gloveSize);

        if (gloveRRenderer.sprite == null) gloveRRenderer.enabled = false;
        else gloveRRenderer.enabled = true;
    }

    public void SetChest(ProductSO chest)
    {
        _chest = chest;
        UpdateVisual();
    }

    public void SetGlove(ProductSO glove)
    {
        _glove = glove;
        UpdateVisual();
    }
}
