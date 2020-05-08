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

## 設定

![2020-05-08_205620](https://user-images.githubusercontent.com/6134875/81403478-7135c200-916e-11ea-8d62-8b43b898f8fb.png)

Preferences から設定を変更できます  

|項目|内容|
|:--|:--|
|Enabled|有効かどうか（デフォルトは OFF）|
|Log Format|エラーログのフォーマット|