using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Note
{
    public class NoteBase : MonoBehaviour
    {
        public float waitSeconds;
        public int sortNumber;

        public NoteBase(float waitSeconds, int sortNumber)
        {
            this.waitSeconds = waitSeconds;
            this.sortNumber = sortNumber;
             
            Debug.Log("NoteのWaitSeconds："+ this.waitSeconds);
            Debug.Log("NoteのSortNumber："+ this.sortNumber);
        }
    }
}