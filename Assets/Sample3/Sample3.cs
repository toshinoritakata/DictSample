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
            new Animal2(0, 0, "トラ", "https://images.pexels.com/photos/145939/pexels-photo-145939.jpeg"),
            new Animal2(1, 0, "リス", "https://images.pexels.com/photos/47547/squirrel-animal-cute-rodents-47547.jpeg"),
            new Animal2(2, 0, "レッサーパンダ", "https://images.pexels.com/photos/145902/pexels-photo-145902.jpeg"),
            new Animal2(3, 2, "タカ", "https://images.pexels.com/photos/151511/pexels-photo-151511.jpeg"),
            new Animal2(4, 2, "メンフクロウ", "https://images.pexels.com/photos/106685/pexels-photo-106685.jpeg"),
            new Animal2(7, 1, "ウミガメ", "https://images.pexels.com/photos/1618606/pexels-photo-1618606.jpeg"),
            new Animal2(6, 1, "カメレオン", "https://images.pexels.com/photos/62289/yemen-chameleon-chamaeleo-calyptratus-chameleon-reptile-62289.jpeg"),
            new Animal2(5, 2, "コンゴウインコ", "https://images.pexels.com/photos/40984/animal-ara-macao-beak-bird-40984.jpeg"),
            new Animal2(8, 1, "アメリカワニ", "https://images.pexels.com/photos/60644/nile-crocodile-crocodylus-niloticus-zoo-60644.jpeg"),
            new Animal2(9, 3, "アカメアマガエル", "https://images.pexels.com/photos/76957/tree-frog-frog-red-eyed-amphibian-76957.jpeg"),
            new Animal2(10, 3, "ヤドクガエル", "https://images.pexels.com/photos/638689/pexels-photo-638689.jpeg"),
        });
        var db = new MemoryDatabase(databaseBuilder.Build());

        _search.onClick.AddListener(() =>
        {
            // 検索結果リストをクリア
            foreach (Transform item in _resultList.transform)
                GameObject.Destroy(item.gameObject);

            // GameObjectの子供番号を検索条件として検索を行う
            var res = Enumerable.Range(0, 4)
                .Where(x => _condition.transform.GetChild(x).GetComponent<Toggle>().isOn)
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
            _image.texture = null;
        }
        else
        {
            _image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}
