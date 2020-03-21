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
            new Animal2(0, "哺乳類", "フクロギツネ", 500, "https://s.yimg.jp/i/kids/zukan/photo/pet/smallanimal/0058/640_480.jpg"),
            new Animal2(1, "哺乳類", "マレーグマ", 1200, "https://s.yimg.jp/i/kids/zukan/photo/animal/mammals/0060/640_480.jpg"),
            new Animal2(2, "哺乳類", "アイアイ", 400, "https://s.yimg.jp/i/kids/zukan/photo/animal/mammals/0029/640_480.jpg"),
            new Animal2(3, "鳥類", "アオサギ", 930, "https://s.yimg.jp/i/kids/zukan/photo/animal/birds/0022/640_480.jpg"),
            new Animal2(4, "鳥類", "コノハズク", 200, "https://s.yimg.jp/i/kids/zukan/photo/animal/birds/0089/640_480.jpg"),
            new Animal2(7, "爬虫類", "カミツキガメ", 300, "https://s.yimg.jp/i/kids/zukan/photo/animal/reptiles/0016/640_480.jpg"),
            new Animal2(6, "爬虫類", "ムカシトカゲ", 600, "https://s.yimg.jp/i/kids/zukan/photo/animal/reptiles/0034/640_480.jpg"),
            new Animal2(5, "鳥類", "セキセイインコ", 180,"https://s.yimg.jp/i/kids/zukan/photo/animal/birds/0084/640_480.jpg"),
            new Animal2(8, "爬虫類", "キングコブラ", 2300, "https://s.yimg.jp/i/kids/zukan/photo/animal/reptiles/0089/640_480.jpg"),
            new Animal2(9, "両生類", "ツチガエル", 40, "https://s.yimg.jp/i/kids/zukan/photo/animal/amphibians/0029/640_480.jpg"),
            new Animal2(10, "両生類", "カメガエル", 50,"https://s.yimg.jp/i/kids/zukan/photo/animal/amphibians/0016/640_480.jpg"),
            new Animal2(11, "両生類", "クロサンショウウオ", 150, "https://s.yimg.jp/i/kids/zukan/photo/animal/amphibians/0001/640_480.jpg")
        });
        var db = new MemoryDatabase(databaseBuilder.Build());

        _search.onClick.AddListener(() =>
        {
            foreach (Transform item in _resultList.transform) 
                GameObject.Destroy(item.gameObject); 

            var cls = Enumerable.Range(0, 4)
                .Select((x, n) => _condition.transform.GetChild(n).GetComponent<Toggle>().isOn ? 
                    db.ClassificationTable.FindById(n).Name : "");

            foreach (var item in db.Animal2Table.All.Where(x => cls.Contains(x.Classification)))
            {
                var obj = GameObject.Instantiate(_namePrefab, _resultList.transform);
                obj.GetComponentInChildren<Text>().text = item.Name;
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
