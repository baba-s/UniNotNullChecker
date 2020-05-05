# Uni Not Null Checker

Inspector で参照が設定されていない NotNull なパラメータが存在したら Unity を再生できなくするエディタ拡張

## 使用例

```cs
using JetBrains.Annotations;
using UnityEngine;

public class Test : MonoBehaviour
{
    [NotNull] public GameObject m_gameObject;
    [NotNull] public Transform  m_transform;
}
```

![2020-05-05_180919](https://user-images.githubusercontent.com/6134875/81050789-9373d980-8efb-11ea-8fd2-7246ced63142.png)

![Image (16)](https://user-images.githubusercontent.com/6134875/81050795-95d63380-8efb-11ea-92c0-12ae2874f184.gif)

## ログ出力のカスタマイズ

```cs
using UniNotNullChecker;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class Example
{
    static Example()
    {
        NotNullChecker.OnLog += data =>
        {
            Debug.LogError( $"参照が設定されていません：{data.RootPath}, {data.ComponentName}, {data.FieldName}", data.Component );
        };
    }
}
```

* 参照が見つからなかった場合に出力されるログはカスタマイズできます  