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
生体計測ですが、今回は**pNN50(快不快指標)** を使っています。自分も講義で習った程度の知識ですが……。  
pNN50については簡単に言うと、**0~1までの値で値が小さいほど不快感やストレスを感じている状態です。**  
このゲームでは、**pNN50の値が小さい、つまりはストレスを感じていている状態である程、移動速度が速くなります**。

##### ゲームをやる時の画像
![pNN_プレイ](https://user-images.githubusercontent.com/45326553/106464629-3b92ef00-64dc-11eb-98e0-a58f9289ba53.jpg)
左の人差し指に付けているのが心拍センサーです。

##### ゲーム画像
![pNN_ピンチ](https://user-images.githubusercontent.com/45326553/106464624-39c92b80-64dc-11eb-9ff4-c1094aa0a99e.jpg)
![pNN_平常](https://user-images.githubusercontent.com/45326553/106464626-3afa5880-64dc-11eb-9b48-182e3d4c4718.jpg)
![pNN_リラックス](https://user-images.githubusercontent.com/45326553/106464628-3afa5880-64dc-11eb-948b-48375228003d.jpg)
