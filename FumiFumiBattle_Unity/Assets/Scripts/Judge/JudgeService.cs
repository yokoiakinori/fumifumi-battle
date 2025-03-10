using Note;
using UnityEngine;

namespace Judge
{
    public class JudgeService
    {
        readonly NotesService _notesService;

        public JudgeService(NotesService notesService)
        {
            _notesService = notesService;
        }
        public void JudgeNote()
        {
            Debug.Log("judgementDistance: "+_notesService.GetFirstJudgementDistance());
        }
    }
}