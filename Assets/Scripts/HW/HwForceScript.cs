using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HwForceScript : MonoBehaviour
{
    private Image indicator;
    private InputAction moveAction;
    private InputSystem_Actions controls;

    public float forceFactor => indicator.fillAmount;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponent<Image>();
        moveAction = controls.Player.Move;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveAction.ReadValue<float>();
        float moveY = moveAction.ReadValue<float>();

        Vector2 moveValue = new Vector2(moveX, moveY);
        float delta = moveValue.x * Time.deltaTime;
        indicator.fillAmount = Mathf.Clamp(indicator.fillAmount + delta, 0.1f, 1.0f);
    }
}
