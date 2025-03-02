using VContainer.Unity;

namespace Note
{
    public class NotePresenter : IStartable
    {
        readonly NotesService _notesService;
        readonly NoteScreen _noteScreen;

        public NotePresenter(NotesService notesService, NoteScreen noteScreen)
        {
            _notesService = notesService;
            _noteScreen = noteScreen;
        }

        void IStartable.Start()
        {
            _noteScreen.setChartButton.onClick.AddListener(() => _notesService.Generate(_noteScreen.noteImage));
            _noteScreen.moveButton.onClick.AddListener(() => _notesService.Move());
        }
    }
}