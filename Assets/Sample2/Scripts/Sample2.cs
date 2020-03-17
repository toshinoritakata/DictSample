using System.Collections;
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
        var databaseBuilder = new DatabaseBuilder();
        databaseBuilder.Append(new List<Animal> {
                    new Animal(1, "哺乳類", "フクロギツネ", 500),
                    new Animal(2, "哺乳類", "マレーグマ", 1200),
                    new Animal(0, "哺乳類", "アイアイ", 400),
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

        var cls = _classSelect.value; 
        var order = _orderSelect.value; 
        _classSelect.onValueChanged.AddListener((int n) => cls = n);
        _orderSelect.onValueChanged.AddListener((int n) => order = n);

        _search.onClick.AddListener(() =>
        {
            if (order == 0)
            {
                _list.text = string.Join("\n",
                    db.AnimalTable.FindByClassification(_classSelect.options[cls].text)
                    .OrderBy(x => x.Name).Select(x => $"{x.Name} {x.Size}mm"));
            }
            else if (order == 1)
            {
                _list.text = string.Join("\n",
                    db.AnimalTable.FindByClassification(_classSelect.options[cls].text)
                    .OrderBy(x => x.Size).Select(x => $"{x.Size}mm {x.Name}"));
            }
        });
    }
}
