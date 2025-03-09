using GameInput;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Note
{
    public class NotePresenter : IStartable
    {
        readonly NotesService _notesService;
        readonly NoteScreen _noteScreen;
        readonly GameInputs _gameInputs;

        public NotePresenter(NotesService notesService, NoteScreen noteScreen)
        {
            _notesService = notesService;
            _noteScreen = noteScreen;
            
            _gameInputs = new GameInputs();
        }

        void IStartable.Start()
        {
            _noteScreen.setChartButton.onClick.AddListener(() => _notesService.Generate());
            _noteScreen.moveButton.onClick.AddListener(() => _notesService.Move());
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