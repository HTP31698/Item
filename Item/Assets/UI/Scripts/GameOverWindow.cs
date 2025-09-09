using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameOverWindow : GenericWindow
{
    public GameObject[] stats;             // 각 스탯 UI (TextMeshProUGUI 붙어 있음)
    public TextMeshProUGUI totalScore;     // 최종 합산 스코어 표시
    public Button button;

    private void Awake()
    {
        // 버튼 연결
        button.onClick.AddListener(OnClickNext);
    }

    public override void Open()
    {
        base.Open();
        StartCoroutine(ShowStatsCoroutine());
    }

    private IEnumerator ShowStatsCoroutine()
    {
        int total = 0;

        // 모든 스탯 텍스트를 미리 숨김
        foreach (var stat in stats)
        {
            stat.SetActive(false);
        }
        totalScore.text = "";

        // 순차적으로 스탯 표시
        for (int i = 0; i < stats.Length; i++)
        {
            var textUI = stats[i].GetComponent<TextMeshProUGUI>();
            int rand = Random.Range(0, 10000);
            total += rand;
            textUI.text = rand.ToString();
            stats[i].SetActive(true);
            yield return new WaitForSeconds(0.5f); // 0.5초 간격으로 표시
        }

        // 모든 스탯 출력 후, 합계 표시
        totalScore.text = $"Total: {total}";
    }

    public void OnClickNext()
    {
        manager.Open(Windows.Start);
    }
}
