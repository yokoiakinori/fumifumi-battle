using UnityEngine;
using UnityEngine.UI;

namespace Note
{
    public class NoteBase
    {
        public float WaitSeconds;
        public int SortNumber;
        public Image Image;

        public NoteBase(float waitSeconds, int sortNumber, Image image)
        {
            this.WaitSeconds = waitSeconds;
            this.SortNumber = sortNumber;
            this.Image = image;
            
            Debug.Log("NoteのWaitSeconds："+ WaitSeconds);
            Debug.Log("NoteのSortNumber："+ SortNumber);
        }
    }
}