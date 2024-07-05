using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SoftwareCursorPositionAdjuster : MonoBehaviour
{
    // InputSystemUIInputModuleへの参照
    [SerializeField] private InputSystemUIInputModule _inputSystemUIInputModule;

    // Canvasへの参照
    [SerializeField] private Canvas _canvas;

    private float _lastScaleFactor = 1;

    // 現在のCanvasスケール
    private float CurrentScale => _canvas.scaleFactor;

    private void Start()
    {
        // InputSystemUIInputModuleとCanvasが指定されていなければ、自動で取得する
        // 参照はインスペクター上で設定することが推奨される
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

    // Canvasのスケールを監視して、VirtualMouseの座標を補正する
    private void Update()
    {
        // Canvasのスケール取得
        var scale = CurrentScale;

        // スケールが変化した時のみ、以降の処理を実行
        if (Math.Abs(scale - _lastScaleFactor) == 0) return;

        // VirtualMouseInputのカーソルのスケールを変更するProcessorを適用
        _inputSystemUIInputModule.point.action.ApplyBindingOverride(new InputBinding
        {
            overrideProcessors = $"VirtualMouseScaler(scale={scale})"
        });

        _lastScaleFactor = scale;
    }
}