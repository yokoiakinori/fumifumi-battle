using GameInput;
using Note;
using Score;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Judge
{
    public class JudgePresenter : IStartable
    {
        readonly GameInputs _gameInputs;
        readonly JudgeService _judgeService;
        readonly ScorePresenter _scorePresenter;
        readonly JudgeView _judgeView;

        public JudgePresenter(JudgeService judgeService, ScorePresenter scorePresenter, JudgeView judgeView)
        {
            _judgeService = judgeService;
            _scorePresenter = scorePresenter;
            
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
            JudgementTable judgementTable = _judgeService.JudgeNote();
            _judgeView.UpdateJudgeText(judgementTable.label);
            _scorePresenter.OnUpdateScore(judgementTable.key);
        }
    }
}