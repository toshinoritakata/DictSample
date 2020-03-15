using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _buttonPrefab = default;
    [SerializeField] private GameObject _containsRoot;

    private Stack<string> _currentPath = new Stack<string>();

    void Start()
    {
        CreateButtonFromFileList("Data");
    }

    void CreateButtonFromFileList(string path)
    {

        foreach (Transform item in _containsRoot.transform)
        {
            GameObject.Destroy(item.gameObject);
        }

        foreach (var dir in System.IO.Directory.GetDirectories(path)) 
        {
            var name = System.IO.Path.GetFileNameWithoutExtension(dir);
            var btn = GameObject.Instantiate(_buttonPrefab, _containsRoot.transform);
            btn.GetComponentInChildren<UnityEngine.UI.Text>().text = name;
            btn.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.black;
            btn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                if (System.IO.Directory.Exists(dir))
                {
                    _currentPath.Push(dir);
                    CreateButtonFromFileList(_currentPath.Peek());
                }
            });
        }

        foreach (var file in System.IO.Directory.GetFiles(path))
        {
            if (System.IO.Path.GetExtension(file).ToLower() != ".jpg") continue;

            var name = System.IO.Path.GetFileNameWithoutExtension(file);
            var btn = GameObject.Instantiate(_buttonPrefab, _containsRoot.transform);
            btn.GetComponent<UnityEngine.UI.Image>().sprite = LoadTextureAsSprite(file);
            btn.GetComponentInChildren<UnityEngine.UI.Text>().text = name;
            btn.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
        }
    }

    public Sprite LoadTextureAsSprite(string path)
    {
        try
        {
            using (var fs = new System.IO.FileStream(path,
                                    System.IO.FileMode.Open,
                                    System.IO.FileAccess.Read))
            {
                using (var bin = new System.IO.BinaryReader(fs))
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
