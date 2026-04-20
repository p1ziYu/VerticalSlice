using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class TextImporter : MonoBehaviour
{
    [Header("TXT 剧本文件拖到这里")]
    public TextAsset storyTextFile;

    void Start()
    {
        if (storyTextFile != null)
        {
            // 1. 按回车换行符把整篇文章切开，忽略空行
            string[] lines = storyTextFile.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

            // 2. 转成 List 格式
            List<string> autoDialogueList = new List<string>(lines);

            Variables.Object(gameObject).Set("dialogueList", autoDialogueList);

            Debug.Log($"导入成功，共导入了 {autoDialogueList.Count} 句台词。");
        }
        else
        {
            Debug.LogWarning("注意：你还没有在 Inspector 里挂载 TXT 剧本文件哦！");
        }
    }
}