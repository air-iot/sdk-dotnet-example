# sdk-dotnet-example

kesi-sdk-gts 开发包示例，每个模块一个最简 Demo。

## 示例列表

| 目录 | 模块 | 说明 |
|------|------|------|
| DriverDemo | 驱动 | 模拟驱动，每 5 秒上报随机温度，并打印平台下发的命令 |
| AlgorithmDemo | 算法 | 加法算法，输入 `{"function":"add","input":{"a":1,"b":2}}`，返回 `result=3` |
| FlowDemo | 流程 | 回显流程，把流程配置中的 message 原样返回 |
| FlowExtensionDemo | 流程扩展 | 翻倍扩展，输入 `{"value":21}`，返回 `{"result":42}` |
| DataRelayDemo | 数据中转 | HttpProxy 接口，原样回显请求体 |
| ServiceDemo | 任务服务 | HTTP 服务，访问 `GET /hello` 返回 `hello`（默认端口 8080） |
| ScheduleDemo | 任务调度 | 定时任务，每 5 秒打印一次当前时间 |

## 运行方式

每个 Demo 都是独立控制台项目，进入对应目录执行：

```
dotnet run
```

需要配置的模块（Driver / Flow / DataRelay / Service / Schedule）在各自 `etc/config.yaml` 中修改连接地址等配置；Algorithm / FlowExtension 由平台侧调度，本地 `dotnet run` 仅启动等待调用。

## 依赖

- .NET 5.0 SDK
- kesi-sdk-gts（当前通过 `..\..\dotnet-sdk\airiot-sdk-feature.csproj` 项目引用，也可改为 NuGet 引用 `kesi-sdk-gts`）
