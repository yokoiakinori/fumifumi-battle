using System.CodeDom.Compiler;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

namespace Note
{
    public class NotesService
    {
        public List<NoteBase> Notes;
        private string _dataPath;
        public void Generate(Image noteImage)
        {
            _dataPath = Application.dataPath+"/Resources/Notes/notes.json";
            List<NoteJsonType> noteJsonType = LoadJsonData();
            foreach (NoteJsonType noteJson in noteJsonType)
            {
                Notes.Add(new NoteBase(noteJson.WaitSeconds, noteJson.SortNumber, noteImage));
            }
        }

        private List<NoteJsonType> LoadJsonData()
        {
            StreamReader streamReader = new StreamReader(_dataPath);
            string jsonString = streamReader.ReadToEnd();
            streamReader.Close();
            
            return JsonConvert.DeserializeObject<List<NoteJsonType>>(jsonString);
        }

        public void Move()
        {
            
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