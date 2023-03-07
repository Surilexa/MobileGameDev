using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bar : MonoBehaviour
{
    [field:SerializeField] public int MaxValue { get; private set; }
    [field:SerializeField] public int Value { get; private set; }

    public RectTransform topBar;

    private float fullWidth;
    private float TargetWidth => Value * fullWidth / MaxValue;

    private void Start()
    {
        fullWidth = topBar.rect.width;
    }

    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Change(20);
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Change(-20);
        }
    }

}
