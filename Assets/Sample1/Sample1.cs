using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Sample1 : MonoBehaviour
{
    [SerializeField] private Button _buttonPrefab;
    [SerializeField] private GameObject _containsRoot;
    [SerializeField] private Button _returnBtn;

    private Stack<string> _currentPath = new Stack<string>();

    void Start()
    {
        // 階層を戻る処理
        _returnBtn.onClick.AddListener(() =>
        {
            if (_currentPath.Count > 1)
            {
                _currentPath.Pop();
                CreateButtonFromFileList(_currentPath.Peek());
            }
        });

        var rootPath = "Data";
        _currentPath.Push(rootPath);
        CreateButtonFromFileList(rootPath);
    }

    void CreateButtonFromFileList(string path)
    {
        // 検索結果を削除
        foreach (Transform item in _containsRoot.transform)
        {
            GameObject.Destroy(item.gameObject);
        }

        // ディレクトリをボタンとしと表示
        foreach (var dir in Directory.GetDirectories(path)) 
        {
            var name = Path.GetFileNameWithoutExtension(dir);
            var btn = GameObject.Instantiate(_buttonPrefab, _containsRoot.transform);
            btn.GetComponentInChildren<Text>().text = name;
            btn.GetComponentInChildren<Text>().color = Color.black;
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (Directory.Exists(dir))
                {
                    _currentPath.Push(dir);
                    CreateButtonFromFileList(_currentPath.Peek());
                }
            });
        }

        // JPG画像を表示
        foreach (var file in Directory.GetFiles(path))
        {
            if (Path.GetExtension(file).ToLower() != ".jpg") continue;

            var name = Path.GetFileNameWithoutExtension(file);
            var btn = GameObject.Instantiate(_buttonPrefab, _containsRoot.transform);
            btn.GetComponent<Image>().sprite = LoadTextureAsSprite(file);
            btn.GetComponentInChildren<Text>().text = name;
            btn.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    public Sprite LoadTextureAsSprite(string path)
    {
        try
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var bin = new BinaryReader(fs))
                {
                    var tex = new Texture2D(1, 1);
                    tex.wrapMode = TextureWrapMode.Clamp;
                    tex.LoadImage(bin.ReadBytes((int)bin.BaseStream.Length));
                    return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
                }
            }
        }
        catch
        {
            return null;
        }
    }
}
