using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Judge
{
    public class JudgeView : MonoBehaviour
    {
        public TextMeshProUGUI judgeText;

        async public void UpdateJudgeText(string text)
        {
            judgeText.text = text;
            judgeText.gameObject.SetActive(true);
            await UniTask.WaitForSeconds(1);
            judgeText.gameObject.SetActive(false);
        }
    }
}