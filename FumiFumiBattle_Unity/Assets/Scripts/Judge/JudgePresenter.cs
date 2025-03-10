using GameInput;
using Note;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Judge
{
    public class JudgePresenter : IStartable
    {
        readonly GameInputs _gameInputs;
        readonly JudgeService _judgeService;

        public JudgePresenter(JudgeService judgeService)
        {
            _judgeService = judgeService;
            
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
            _judgeService.JudgeNote();
        }
    }
}