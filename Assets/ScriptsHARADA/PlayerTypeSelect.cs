using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeSelect : MonoBehaviour
{
    [SerializeField, Header("キャラクタータイプ")]
    private PlayerType _playerType = default;
    public enum PlayerType
    {
        Dog,
        Bear,
        Cat,
        Dear,
        Duck,
        Fox,
        Racoon,
        Shark,
        Tiger
    }

    public PlayerType playerType { get => _playerType; }
}
