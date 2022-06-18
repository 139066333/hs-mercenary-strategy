# 佣兵插件策略

## 仓库说明
本仓库为[炉石佣兵插件](https://github.com/jimowushuang/hs-mercenary)的策略源码，欢迎mr。

## 如何自定义策略
1. 新建一个类，实现`IStrategy`接口。参考[PVE火焰队策略](https://github.com/jimowushuang/hs-mercenary-strategy/blob/master/hs-mercenary-strategy/FireStrategy.cs) 注意策略名不能和已有策略名重复。
2. 编译解决方案。将编译产物放进`BepInEx\plugins\`目录下，覆盖即可。
3. 进入游戏，按F1打开配置选择你的策略名称调试即可。

## 交流群
QQ群: 792054397