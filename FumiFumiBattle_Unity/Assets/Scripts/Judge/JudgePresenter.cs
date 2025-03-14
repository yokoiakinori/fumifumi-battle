using GameInput;
using Note;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Judge
{
    public class JudgePresenter : IStartable
    {
        readonly GameInputs _gameInputs;
        readonly JudgeService _judgeService;
        readonly JudgeView _judgeView;

        public JudgePresenter(JudgeService judgeService, JudgeView judgeView)
        {
            _judgeService = judgeService;
            _judgeView = judgeView;
            
            _gameInputs = new GameInputs();
        }

        void IStartable.Start()
        {
            _gameInputs.Player.MoveTop.performed += OnJudge;
            _gameInputs.Player.MoveDown.performed += OnJudge;
            _gameInputs.Player.MoveLeft.performed += OnJudge;
            _gameInputs.Player.MoveRight.performed += OnJudge;
            
            _gameInputs.Enable();
        }

        void OnJudge(InputAction.CallbackContext context)
        {
            string judgeLabel = _judgeService.JudgeNote();
            Debug.Log(judgeLabel);
            _judgeView.UpdateJudgeText(judgeLabel);
        }
    }
}