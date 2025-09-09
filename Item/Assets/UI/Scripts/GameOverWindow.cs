using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameOverWindow : GenericWindow
{
    public GameObject[] stats;             // �� ���� UI (TextMeshProUGUI �پ� ����)
    public TextMeshProUGUI totalScore;     // ���� �ջ� ���ھ� ǥ��
    public Button button;

    private void Awake()
    {
        // ��ư ����
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

        // ��� ���� �ؽ�Ʈ�� �̸� ����
        foreach (var stat in stats)
        {
            stat.SetActive(false);
        }
        totalScore.text = "";

        // ���������� ���� ǥ��
        for (int i = 0; i < stats.Length; i++)
        {
            var textUI = stats[i].GetComponent<TextMeshProUGUI>();
            int rand = Random.Range(0, 10000);
            total += rand;
            textUI.text = rand.ToString();
            stats[i].SetActive(true);
            yield return new WaitForSeconds(0.5f); // 0.5�� �������� ǥ��
        }

        // ��� ���� ��� ��, �հ� ǥ��
        totalScore.text = $"Total: {total}";
    }

    public void OnClickNext()
    {
        manager.Open(Windows.Start);
    }
}
