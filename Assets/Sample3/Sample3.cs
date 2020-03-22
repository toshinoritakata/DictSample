using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using CGWORLD;
using System.Linq;
using UnityEngine.UI;

public class Sample3 : MonoBehaviour
{
    [SerializeField] GameObject _condition;
    [SerializeField] GameObject _resultList;
    [SerializeField] GameObject _namePrefab;
    [SerializeField] Button _search;
    [SerializeField] RawImage _image;
    void Start()
    {
        //　動物データを登録します
        var databaseBuilder = new DatabaseBuilder();
        databaseBuilder.Append((new List<string> {
            "哺乳類", "爬虫類", "鳥類", "両生類"
        }).Select((name, index) => new Classification(index, name)));

        databaseBuilder.Append(new List<Animal2> {
            new Animal2(0, 0, "フクロギツネ", 500, "https://s.yimg.jp/i/kids/zukan/photo/pet/smallanimal/0058/640_480.jpg"),
            new Animal2(1, 0, "マレーグマ", 1200, "https://s.yimg.jp/i/kids/zukan/photo/animal/mammals/0060/640_480.jpg"),
            new Animal2(2, 0, "アイアイ", 400, "https://s.yimg.jp/i/kids/zukan/photo/animal/mammals/0029/640_480.jpg"),
            new Animal2(3, 2, "アオサギ", 930, "https://s.yimg.jp/i/kids/zukan/photo/animal/birds/0022/640_480.jpg"),
            new Animal2(4, 2, "コノハズク", 200, "https://s.yimg.jp/i/kids/zukan/photo/animal/birds/0089/640_480.jpg"),
            new Animal2(7, 1, "カミツキガメ", 300, "https://s.yimg.jp/i/kids/zukan/photo/animal/reptiles/0016/640_480.jpg"),
            new Animal2(6, 1, "ムカシトカゲ", 600, "https://s.yimg.jp/i/kids/zukan/photo/animal/reptiles/0034/640_480.jpg"),
            new Animal2(5, 2, "セキセイインコ", 180,"https://s.yimg.jp/i/kids/zukan/photo/animal/birds/0084/640_480.jpg"),
            new Animal2(8, 1, "キングコブラ", 2300, "https://s.yimg.jp/i/kids/zukan/photo/animal/reptiles/0089/640_480.jpg"),
            new Animal2(9, 3, "ツチガエル", 40, "https://s.yimg.jp/i/kids/zukan/photo/animal/amphibians/0029/640_480.jpg"),
            new Animal2(10, 3, "カメガエル", 50,"https://s.yimg.jp/i/kids/zukan/photo/animal/amphibians/0016/640_480.jpg"),
            new Animal2(11, 3, "クロサンショウウオ", 150, "https://s.yimg.jp/i/kids/zukan/photo/animal/amphibians/0001/640_480.jpg")
        });
        var db = new MemoryDatabase(databaseBuilder.Build());

        _search.onClick.AddListener(() =>
        {
            // 検索結果リストをクリア
            foreach (Transform item in _resultList.transform)
                GameObject.Destroy(item.gameObject);

            // GameObjectの子供番号を検索条件として検索を行う
            var res = Enumerable.Range(0, 4)
                .Where((x, n) => _condition.transform.GetChild(n).GetComponent<Toggle>().isOn)
                .SelectMany(x => db.Animal2Table.FindByClassification(x));

            // 検索結果を表示
            foreach (var item in res)
            {
                var cls = db.ClassificationTable.FindById(item.Classification).Name;
                var obj = GameObject.Instantiate(_namePrefab, _resultList.transform);
                obj.GetComponentInChildren<Text>().text = $"{cls}|{item.Name}";
                obj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    StartCoroutine(GetTexture(item.Url));
                });
            }
        });
    }

    IEnumerator GetTexture(string url)
    {
        var www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            _image.texture = null;
        }
        else
        {
            _image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}
