using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] GameObject root;
    [SerializeField] GameObject gridCellPrefab;
    [SerializeField] GridLayoutGroup gridLayout;

    Item[,] items;

    bool inventoryOpen;

    private void Start()
    {
        Initialize(rows, columns);
    }

    #region Logic

    public void Initialize(int rows, int columns)
    {
        for (int i = 0; i < root.transform.childCount; i++)
        {
            Transform child = root.transform.GetChild(i);
            Destroy(child.gameObject);
        }


        RectTransform rootTransform = root.transform as RectTransform;
        items = new Item[rows, columns];
        for (int i = 0; i < rows * columns; i++)
        {
            Instantiate(gridCellPrefab, rootTransform);
        }

        rootTransform.anchoredPosition = new Vector2(gridLayout.cellSize.x * (-columns / 2f), gridLayout.cellSize.y * (rows / 2f));
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        gridLayout.constraintCount = rows;
    }

    public void PlaceItem()
    {

    }

    public void RemoveItem()
    {

    }

    public void ToggleInventory()
    {
        if (inventoryOpen)
            CloseInventory();
        else
            OpenInventory();
    }

    public void OpenInventory()
    {
        inventoryOpen = true;
        ShowInventory();
    }

    public void CloseInventory()
    {
        inventoryOpen = false;
        HideInventory();
    }

    #endregion


    #region Renderer

    public void ShowInventory()
    {
        root.SetActive(true);
    }

    public void HideInventory()
    {
        root.SetActive(false);
    }

    #endregion


    #region Input

    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
            ToggleInventory();
    }

    #endregion
}

class Item
{
    string name;
    Sprite sprite;
}