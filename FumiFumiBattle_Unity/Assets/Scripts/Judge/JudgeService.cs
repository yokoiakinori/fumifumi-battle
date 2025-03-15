using System.Collections.Generic;
using Note;
using UnityEngine;

namespace Judge
{
    public class JudgeService
    {
        readonly NotesService _notesService;
        Dictionary<int, JudgementTable> _judgementTable;

        public JudgeService(NotesService notesService)
        {
            _notesService = notesService;
            _judgementTable = new Dictionary<int, JudgementTable>
            {
                {1, new JudgementTable(1, "良", 30)},
                {2, new JudgementTable(2, "可", 60)},
                {3, new JudgementTable(3, "不可", 90)},
            };
        }
        public JudgementTable JudgeNote()
        {
            int absdistance = Mathf.Abs(_notesService.GetFirstJudgementDistance());
            int judgementTableIndex = 1;

            while (absdistance > _judgementTable[judgementTableIndex].maxJudgementDistance && judgementTableIndex < _judgementTable.Count)
            {
                judgementTableIndex++;
            }

            return _judgementTable[judgementTableIndex];
        }
    }

    public class JudgementTable
    {
        public readonly int key;
        public readonly string label;
        public readonly int maxJudgementDistance;

        public JudgementTable(int key, string label, int maxJudgementDistance)
        {
            this.key = key;
            this.label = label;
            this.maxJudgementDistance = maxJudgementDistance;
        }
    }
}