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
                {1, new JudgementTable("良", 30)},
                {2, new JudgementTable("可", 60)},
                {3, new JudgementTable("不可", 90)},
            };
        }
        public void JudgeNote()
        {
            int absdistance = Mathf.Abs(_notesService.GetFirstJudgementDistance());
            int judgementTableIndex = 1;

            while (absdistance > _judgementTable[judgementTableIndex].maxJudgementDistance && judgementTableIndex < _judgementTable.Count)
            {
                judgementTableIndex++;
            }
            Debug.Log("判定: "+_judgementTable[judgementTableIndex].label);
        }
    }

    public class JudgementTable
    {
        public readonly string label;
        public readonly int maxJudgementDistance;

        public JudgementTable(string label, int maxJudgementDistance)
        {
            this.label = label;
            this.maxJudgementDistance = maxJudgementDistance;
        }
    }
}