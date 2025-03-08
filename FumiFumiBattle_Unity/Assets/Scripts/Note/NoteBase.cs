using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace Note
{
    public class NoteBase : MonoBehaviour
    {
        public float waitSeconds;
        public int sortNumber;

        private bool _isMoving;

        public NoteBase(float waitSeconds, int sortNumber)
        {
            this.waitSeconds = waitSeconds;
            this.sortNumber = sortNumber;
            _isMoving = false;
             
            Debug.Log("NoteのWaitSeconds："+ this.waitSeconds);
            Debug.Log("NoteのSortNumber："+ this.sortNumber);
        }

        public async UniTask MoveNote()
        {
            await UniTask.Delay(TimeSpan.FromMilliseconds(waitSeconds));
            _isMoving = true;
            return;
        }

        public void Update()
        {
            if (_isMoving)
            {
                Vector3 pos = transform.position;
                pos.x -= 1.0f;
                transform.position = pos;
            }
        }
    }
}