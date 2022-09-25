using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R60N.Utility;

public class StaminaDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform barTransform;
    [SerializeField] private Stamina stamina;

    private void Start()
    {
        stamina.Changed += UpdateStamina;
    }

    private void UpdateStamina()
    {
        barTransform.localScale = barTransform.localScale.WithX(stamina.CurrentStamina / stamina.MaxStamina);
    }
}