using UnityEngine;
using UnityEngine.InputSystem;

public class GameEnd : MonoBehaviour
{
    //ゲーム終了:ボタンから呼び出す
    public void EndGame(InputAction.CallbackContext context)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
