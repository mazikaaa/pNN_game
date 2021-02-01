## ゲームの開き方
① code(黄緑色のボタン)→Download ZIPよりフォルダをダウンロード  
②「gamefile」のフォルダをクリック  
③「pNNgame.exe」をクリック  

**このゲームを最大限遊んでもらうためには、「心拍センサー」とArudinoなどの「マイコンボード」が必要になります。**

## 生体計測を使った「鬼ごっこ風」ゲーム

#### 内容
大学の講義での発表のために作成したゲームになっています。「生体計測を用いたアプリケーション作成」の課題になっています。  
ロボットに見つからないようにしながら、マップ上に落ちているコインを回収するゲームになっています。ロボットに見つかると追いかけてきて捕まるとゲームオーバーです。  
自分がストレスや不快感を感じると、プレイヤーの移動速度が速くなります。  

#### 生体計測について
生体計測ですが、今回は**pNN50** を使っています。自分も講義で習った程度の知識ですが……。  
pNN50については簡単に言うと、**心拍の揺らぎの大きさの指標で、値が小さいほど不快感やストレスを感じている状態です。**  
このゲームでは、**pNN50の値が小さい、つまりはストレスを感じていている状態である程、移動速度が速くなります**。

##### 使用した機器  
心拍センサー……[Pulse sensor](https://www.amazon.co.jp/KOZEEY-STK0151000071-%E5%BF%83%E6%8B%8D-%E3%83%8F%E3%83%BC%E3%83%88%E3%83%AC%E3%83%BC%E3%83%88-%E5%BF%83%E6%8B%8D%E6%95%B0%E3%82%92%E3%83%86%E3%82%B9%E3%83%88-%E8%84%88%E6%8B%8D%E3%82%BB%E3%83%B3%E3%82%B5%E3%83%BC-%E3%83%91%E3%83%AB%E3%82%B9%E3%82%BB%E3%83%B3%E3%82%B5%E3%83%A2%E3%82%B8%E3%83%A5%E3%83%BC%E3%83%AB-3-3V%E3%80%9C5V/dp/B01CFGOZM0/ref=sr_1_1?__mk_ja_JP=%E3%82%AB%E3%82%BF%E3%82%AB%E3%83%8A&dchild=1&keywords=Pulse+sensor&qid=1612186876&sr=8-1)   
![Pulus Monitor](https://user-images.githubusercontent.com/45326553/106469697-f8884a00-64e2-11eb-8054-6f86835a699b.png)　　　　
マイコンボード……[Aruduino Uno R3](https://www.amazon.co.jp/ELEGOO-ATmega328P-ATMEGA16U2-USB%E3%82%B1%E3%83%BC%E3%83%96%E3%83%AB-Arduino%E7%94%A8/dp/B06Y5TBNQX/ref=sr_1_5?__mk_ja_JP=%E3%82%AB%E3%82%BF%E3%82%AB%E3%83%8A&dchild=1&keywords=arudino+uno+R3&qid=1612178401&sr=8-5)　　
![Arudino](https://user-images.githubusercontent.com/45326553/106469692-f7571d00-64e2-11eb-8709-6d9af85febf4.png)　　


##### ゲームをやる時の画像
![pNN_プレイ](https://user-images.githubusercontent.com/45326553/106464629-3b92ef00-64dc-11eb-98e0-a58f9289ba53.jpg)  
左の人差し指に付けているのが心拍センサーです。

##### ゲーム画像
![pNN_ピンチ](https://user-images.githubusercontent.com/45326553/106464624-39c92b80-64dc-11eb-9ff4-c1094aa0a99e.jpg)
![pNN_平常](https://user-images.githubusercontent.com/45326553/106464626-3afa5880-64dc-11eb-9b48-182e3d4c4718.jpg)
![pNN_リラックス](https://user-images.githubusercontent.com/45326553/106464628-3afa5880-64dc-11eb-948b-48375228003d.jpg)

 ##### 作成時間
 15~20時間
 
 ##### 作成人数
 １人

  ##### 開発環境
  ・Unity(2019.1.14f)  

## ソースコードについて
以下のURLより見ることが出来ます。  
https://github.com/mazikaaa/pNN_game/tree/master/Assets/Script
