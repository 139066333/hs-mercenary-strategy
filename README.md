# 佣兵插件策略

## 仓库说明
本仓库为[炉石佣兵插件](https://github.com/jimowushuang/hs-mercenary)的策略源码，欢迎mr。

## 如何自定义策略
1. 克隆本仓库
2. 新建一个类，实现`IStrategy`接口。参考[PVE火焰队策略](https://github.com/jimowushuang/hs-mercenary-strategy/blob/master/hs-mercenary-strategy/FireStrategy.cs) 注意策略名不能和已有策略名重复。
3. 编译解决方案。将编译产物放进`BepInEx\plugins\`目录下，覆盖即可。
4. 进入游戏，按F1打开配置选择你的策略名称调试即可。

## 关于PVP
原则上我是不支持的。因此我不会主动参与策略的编写，但是欢迎mr

## 交流群
QQ群: 792054397
