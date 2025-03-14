using System.CodeDom.Compiler;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using VContainer;
using VContainer.Unity;

namespace Note
{
    public class NotesService
    {
        private readonly NoteBase prefab;
        private readonly IObjectResolver resolver;
        private readonly Transform parentTransform;
        
        private List<NoteBase> _beforeNotes;
        private List<NoteBase> _afterNotes;
        private string _dataPath;

        public NotesService(NoteBase prefab, IObjectResolver resolver, Transform parentTransform)
        {
            this.prefab = prefab;
            this.resolver = resolver;
            this.parentTransform = parentTransform;
        }
        public void Generate()
        {
            _dataPath = Application.dataPath+"/Resources/Notes/notes.json";
            List<NoteJsonType> noteJsonType = LoadJsonData();
            _beforeNotes = new List<NoteBase>();
            _afterNotes = new List<NoteBase>();
            foreach (NoteJsonType noteJson in noteJsonType)
            {
                NoteBase instance = resolver.Instantiate(prefab);
                instance.Construct(noteJson.WaitSeconds, noteJson.SortNumber);

                instance.transform.SetPositionAndRotation(new Vector3(550, -100, 0), Quaternion.identity); // TODO: 後で修正
                instance.transform.SetParent(parentTransform, false);
                _beforeNotes.Add(instance);
            }
        }

        private List<NoteJsonType> LoadJsonData()
        {
            StreamReader streamReader = new StreamReader(_dataPath);
            string jsonString = streamReader.ReadToEnd();
            streamReader.Close();
            
            return JsonConvert.DeserializeObject<List<NoteJsonType>>(jsonString);
        }

        public async void Move()
        {
            while (_beforeNotes.Count > 0)
            {
                NoteBase note = _beforeNotes.First();
                _beforeNotes.Remove(note);
                _afterNotes.Add(note);
                await note.MoveNote();
            }
        }

        public void DeleteNote()
        {
            Debug.Log("Noteの削除処理");
            NoteBase note = _afterNotes.First();
            note.DestroyObject();
            _afterNotes.Remove(note);
            
        }

        public int GetFirstJudgementDistance()
        {
            return _afterNotes.First().GetJudgementDistance();
        }
    }
    
    [JsonObject]
    public class NoteJsonType
    {
        [JsonProperty("WaitSeconds")]
        public float WaitSeconds { get; set; }

        [JsonProperty("SortNumber")]
        public int SortNumber { get; set; }
    }
}