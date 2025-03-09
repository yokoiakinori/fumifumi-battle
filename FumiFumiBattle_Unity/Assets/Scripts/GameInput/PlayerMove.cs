using UnityEngine;
using UnityEngine.InputSystem;

namespace GameInput
{
    public class PlayerMove: MonoBehaviour
    {
        private GameInputs _gameInputs;
        
        private void Awake()
        {
            // Actionスクリプトのインスタンス生成
            _gameInputs = new GameInputs();

            // Actionイベント登録
            _gameInputs.Player.MoveTop.performed += OnMoveTop;
            _gameInputs.Player.MoveDown.performed += OnMoveDown;
            _gameInputs.Player.MoveLeft.performed += OnMoveLeft;
            _gameInputs.Player.MoveRight.performed += OnMoveRight;

            // Input Actionを機能させるためには、
            // 有効化する必要がある
            _gameInputs.Enable();
        }

        public void OnMoveTop(InputAction.CallbackContext context)
        {
            Debug.Log("上入力");
        }
        
        public void OnMoveDown(InputAction.CallbackContext context)
        {
            Debug.Log("下入力");
        }
        
        public void OnMoveLeft(InputAction.CallbackContext context)
        {
            Debug.Log("左入力");
        }
        
        public void OnMoveRight(InputAction.CallbackContext context)
        {
            Debug.Log("右入力");
        }
    }
}