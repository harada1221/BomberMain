using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleManeger : MonoBehaviour
{
    [SerializeField]
    private Animator _anim = default;
    [SerializeField]
    private GameObject _anykeyText = default;
    [SerializeField]
    private GameObject _selectText = default;
    private InputAction _pressAnyKeyAction =
                new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");

    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();

    private TitleType _titleType = TitleType.First;
    public enum TitleType
    {
        First,
        Second
    }

    private void Update()
    {
        switch (_titleType)
        {
            case TitleType.First:
                if (_pressAnyKeyAction.triggered)
                {
                    _anim.SetBool("AnyButtun", true);
                    _anykeyText.SetActive(false);
                    _selectText.SetActive(true);
                    _titleType = TitleType.Second;
                }
                break;
            case TitleType.Second:
                break;
        }
    }
}
