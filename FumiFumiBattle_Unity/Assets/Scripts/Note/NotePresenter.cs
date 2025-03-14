using GameInput;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Note
{
    public class NotePresenter : IStartable
    {
        readonly NotesService _notesService;
        readonly NoteView _noteView;
        readonly GameInputs _gameInputs;

        public NotePresenter(NotesService notesService, NoteView noteView)
        {
            _notesService = notesService;
            _noteView = noteView;
            
            _gameInputs = new GameInputs();
        }

        void IStartable.Start()
        {
            _noteView.setChartButton.onClick.AddListener(() => _notesService.Generate());
            _noteView.moveButton.onClick.AddListener(() => _notesService.Move());
            _gameInputs.Player.MoveTop.performed += OnControlNote;
            _gameInputs.Player.MoveDown.performed += OnControlNote;
            _gameInputs.Player.MoveLeft.performed += OnControlNote;
            _gameInputs.Player.MoveRight.performed += OnControlNote;
            
            _gameInputs.Enable();
        }

        void OnControlNote(InputAction.CallbackContext context)
        {
            _notesService.DeleteNote();
        }
    }
}