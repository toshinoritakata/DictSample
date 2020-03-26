# Unityで作る図鑑コンテンツの実装サンプル

# sample1.unity
## DataフォルダをUIに反映させる

画像は https://www.pexels.com/ から

![sample1](https://user-images.githubusercontent.com/529150/77245013-a5a4fb80-6c5e-11ea-9bc9-d303522f065d.gif)

# sample2.unity
## 動物データをMasterMemoryで検索する

|類|名前|大きさ(mm)|
|---|---|---|
|哺乳類|フクロギツネ|500|
|哺乳類|マレーグマ|1200|
|哺乳類|アイアイ|400 |
|鳥類|アオサギ| 930|
|鳥類|コノハズク| 200|
|爬虫類|カミツキガメ| 300|
|爬虫類|ムカシトカゲ| 600|
|鳥類|セキセイインコ| 180|
|爬虫類|キングコブラ| 2300|
|両生類|ツチガエル| 40|
|両生類|カメガエル| 50|
|両生類|クロサンショウウオ| 150|

![sample2](https://user-images.githubusercontent.com/529150/77245061-06cccf00-6c5f-11ea-9ec7-1fc86e939f4b.gif)


# sample3.unity
## MasterMemoryでOR検索して検索結果を画像で表示する

### 分類登録テーブル
|番号|分類|
|---|---|
|0|哺乳類|
|1|爬虫類|
|2|鳥類|
|3|両生類|

### 登録テーブル
|分類番号|名前|画像URL|
|---|---|---|
|0|トラ|https://images.pexels.com/photos/145939/pexels-photo-145939.jpeg|
|0|リス|https://images.pexels.com/photos/47547/squirrel-animal-cute-rodents-47547.jpeg|
|0|レッサーパンダ|https://images.pexels.com/photos/145902/pexels-photo-145902.jpeg|
|2|タカ|https://images.pexels.com/photos/151511/pexels-photo-151511.jpeg|
|2|メンフクロウ|https://images.pexels.com/photos/106685/pexels-photo-106685.jpeg|
|1|ウミガメ|https://images.pexels.com/photos/1618606/pexels-photo-1618606.jpeg|
|1|カメレオン|https://images.pexels.com/photos/62289/yemen-chameleon-chamaeleo-calyptratus-chameleon-reptile-62289.jpeg|
|2|コンゴウインコ|https://images.pexels.com/photos/40984/animal-ara-macao-beak-bird-40984.jpeg|
|1|アメリカワニ|https://images.pexels.com/photos/60644/nile-crocodile-crocodylus-niloticus-zoo-60644.jpeg|
|3|アカメアマガエル|https://images.pexels.com/photos/76957/tree-frog-frog-red-eyed-amphibian-76957.jpeg|
|3|ヤドクガエル|https://images.pexels.com/photos/638689/pexels-photo-638689.jpeg|


![sample3](https://user-images.githubusercontent.com/529150/77606923-32500200-6f5c-11ea-947d-f11ec051adbf.gif)
