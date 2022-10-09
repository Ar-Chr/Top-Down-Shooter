using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private AmmoStats ammo;
    [Space]
    [Header("Output")]
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        inventory.AmmoChanged += HandleAmmoChanged;

        icon.sprite = ammo.Icon;
        UpdateAmmoCount();
    }

    private void HandleAmmoChanged()
    {
        UpdateAmmoCount();
    }

    private void UpdateAmmoCount()
    {
        text.text = inventory.GetAmmoCount(ammo).ToString();
    }
}
