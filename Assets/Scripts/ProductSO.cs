using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Product/Create New Product", order = 1)]

public class ProductSO : ScriptableObject
{
  public Sprite asset;
  public int price;
  public enum Category {Hat, Glove, Chest, Pet};
  public Category category;

}
