using System.CodeDom.Compiler;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using VContainer;
using VContainer.Unity;

namespace Note
{
    public class NotesService
    {
        private readonly NoteBase prefab;
        private readonly IObjectResolver resolver;
        private readonly Transform parentTransform;
        
        public List<NoteBase> Notes;
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
            Notes = new List<NoteBase>();
            foreach (NoteJsonType noteJson in noteJsonType)
            {
                NoteBase instance = resolver.Instantiate(prefab);
                instance.transform.SetPositionAndRotation(new Vector3(550, -100, 0), Quaternion.identity); // TODO: 後で修正
                instance.waitSeconds = noteJson.WaitSeconds;
                instance.sortNumber = noteJson.SortNumber;
                instance.transform.SetParent(parentTransform, false);
                Notes.Add(instance);
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