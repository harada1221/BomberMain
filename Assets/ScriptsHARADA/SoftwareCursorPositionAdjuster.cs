using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SoftwareCursorPositionAdjuster : MonoBehaviour
{
    // InputSystemUIInputModule�ւ̎Q��
    [SerializeField] private InputSystemUIInputModule _inputSystemUIInputModule;

    // Canvas�ւ̎Q��
    [SerializeField] private Canvas _canvas;

    private float _lastScaleFactor = 1;

    // ���݂�Canvas�X�P�[��
    private float CurrentScale => _canvas.scaleFactor;

    private void Start()
    {
        // InputSystemUIInputModule��Canvas���w�肳��Ă��Ȃ���΁A�����Ŏ擾����
        // �Q�Ƃ̓C���X�y�N�^�[��Őݒ肷�邱�Ƃ����������
        if (_inputSystemUIInputModule == null)
        {
            var modules =
                FindObjectsByType<InputSystemUIInputModule>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            if (modules.Length > 0) _inputSystemUIInputModule = modules[0];
        }

        if (_canvas == null)
        {
            var canvases = FindObjectsByType<Canvas>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            if (canvases.Length > 0) _canvas = canvases[0];
        }
    }

    // Canvas�̃X�P�[�����Ď����āAVirtualMouse�̍��W��␳����
    private void Update()
    {
        // Canvas�̃X�P�[���擾
        var scale = CurrentScale;

        // �X�P�[�����ω��������̂݁A�ȍ~�̏��������s
        if (Math.Abs(scale - _lastScaleFactor) == 0) return;

        // VirtualMouseInput�̃J�[�\���̃X�P�[����ύX����Processor��K�p
        _inputSystemUIInputModule.point.action.ApplyBindingOverride(new InputBinding
        {
            overrideProcessors = $"VirtualMouseScaler(scale={scale})"
        });

        _lastScaleFactor = scale;
    }
}