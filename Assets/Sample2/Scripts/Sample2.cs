using System.Collections.Generic;
using UnityEngine;
using CGWORLD;
using System.Linq;

public class Sample2 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Dropdown _classSelect;
    [SerializeField] UnityEngine.UI.Dropdown _orderSelect;
    [SerializeField] UnityEngine.UI.Button _search;
    [SerializeField] UnityEngine.UI.Text _list;
    void Start()
    {
        //　動物データを登録します
        var databaseBuilder = new DatabaseBuilder();
        databaseBuilder.Append(new List<Animal> {
                    new Animal(0, "哺乳類", "フクロギツネ", 500),
                    new Animal(1, "哺乳類", "マレーグマ", 1200),
                    new Animal(2, "哺乳類", "アイアイ", 400),
                    new Animal(3, "鳥類", "アオサギ", 930),
                    new Animal(4, "鳥類", "コノハズク", 200),
                    new Animal(7, "爬虫類", "カミツキガメ", 300),
                    new Animal(6, "爬虫類", "ムカシトカゲ", 600),
                    new Animal(5, "鳥類", "セキセイインコ", 180),
                    new Animal(8, "爬虫類", "キングコブラ", 2300),
                    new Animal(9, "両生類", "ツチガエル", 40),
                    new Animal(10, "両生類", "カメガエル", 50),
                    new Animal(11, "両生類", "クロサンショウウオ", 150)});
        var db = new MemoryDatabase(databaseBuilder.Build());

        // 検索ボタンが押されたらDropBoxで選ばれている条件に従って、動物を表示する
        _search.onClick.AddListener(() =>
        {
            var cls = db.AnimalTable.FindByClassification(_classSelect.options[_classSelect.value].text);
            _list.text = string.Join("\n", (_orderSelect.value == 0) ?
                cls.OrderBy(x => x.Name).Select(x => $"{x.Name} {x.Size}mm") :
                cls.OrderBy(x => x.Size).Select(x => $"{x.Size}mm {x.Name}"));
        });
    }
}
