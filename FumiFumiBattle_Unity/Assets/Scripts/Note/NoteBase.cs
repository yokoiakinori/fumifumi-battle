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
        
        private int _judgementDistance;

        public void Construct(float waitSeconds, int sortNumber)
        {
            this.waitSeconds = waitSeconds;
            this.sortNumber = sortNumber;
            _isMoving = false;
            
            _judgementDistance = 1000;
            
            Debug.Log("初期judgementDistance: "+_judgementDistance);
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
                _judgementDistance--;
            }
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }

        public int GetJudgementDistance()
        {
            return _judgementDistance;
        }
    }
}