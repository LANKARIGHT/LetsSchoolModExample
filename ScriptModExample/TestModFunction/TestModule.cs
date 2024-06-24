using FrameworkNs;
using FrameworkNs.ArchiveNs;
using FrameworkNs.IoC;
using FrameworkNs.UtilitiesNs;
using ProjectSchoolModNs.Publish;
using ProjectSchoolNs.CharacterNs;
using ProjectSchoolNs.WorldNs;
using System;

namespace TestModFunction
{
    // 游戏中的模块
    // In-game modules
    class TestModule : M_GameModuleBase, IArchiveableModule, IArchiveBeforeLoadProcessModule, IArchiveAfterLoadProcessModule, IArchiveBeforeSaveProcessModule, IArchiveAfterSaveProcessModule
    {
        // 游戏上下文接口
        // Game context interface
        M_IGameContext gameContext;
        // 服务容器
        // service container
        IServiceContainer serviceContainer;
        protected override void OnCreate()
        {
            // 从模组上下文中获取游戏上下文接口
            // Gets the game context interface from the module context
            modContext.RunnerContext.TryGetContext(out gameContext);
            // 获取服务容器
            // Get service container
            serviceContainer = gameContext.Publish.FirstTWithGC<IServiceContainer>();
        }

        protected override void OnLoad()
        {
            // 模块加载
            modContext.LogError("Module Load");
        }

        protected override void OnStart()
        {
            // 模块启动
            modContext.LogError("Module Start");
        }
        void IArchiveBeforeLoadProcessModule.OnBeforeLoadArchive(ArchiveContext archiveContext)
        {
            // 开始加载存档
            modContext.LogError("Before Load Archive");
        }

        void IArchiveableModule.OnLoadArchive(ArchiveContext archiveContext)
        {
            // 加载存档
            modContext.LogError("Load Archive");
            if (archiveContext.IsNewArchive)
            {
                // TODO: 新游戏处理
                // TODO: new game process
            }
            else
            {
                // 获取存档数据
                // Get archive data
                var saveData = archiveContext.GetData<SaveData>();
                // TODO: 非新游戏处理
                // TODO: not new game process
            }
        }

        void IArchiveAfterLoadProcessModule.OnAfterLoadArchive(ArchiveContext archiveContext)
        {
            // 结束加载存档
            modContext.LogError("After Load Archive");
        }

        void IArchiveBeforeSaveProcessModule.OnBeforeSaveArchive(ArchiveContext archiveContext)
        {
            // 开始保存存档
            modContext.LogError("Before Save Archive");
        }

        void IArchiveableModule.OnSaveArchive(ArchiveContext archiveContext)
        {
            // 保存存档
            modContext.LogError("Save Archive");

            // 获取模块管理器
            // Gets the module manager
            var moduleManager = serviceContainer.GetService<ModuleManager>();
            // 获取地图模块
            // Get map module
            var mapModule = moduleManager.GetModule<MapModule>();
            // 获取角色模块
            // Get character module
            var characterModule = moduleManager.GetModule<CharacterModule>();
            // 获取用于存档的数据
            // Gets data for archiving
            var saveData = archiveContext.GetData<SaveData>();
            saveData.Test = $"CharacterCount:{characterModule.characterList.Count} MapSize:{mapModule.MapSize}";
        }

        void IArchiveAfterSaveProcessModule.OnAfterSaveArchive(ArchiveContext archiveContext)
        {
            // 结束保存存档
            modContext.LogError("After Save Archive");
        }

        protected override void OnStop()
        {
            // 模块停止
            modContext.LogError("Module Stop");
        }

        protected override void OnUnload()
        {
            // 模块卸载
            modContext.LogError("Module Unload");
        }

        protected override void OnDispose()
        {
            // 模块释放
            modContext.LogError("Module Dispose");
        }

        // 数据唯一标识
        // Data unique identification
        [ArchiveDataIdentity("Mod.TestModule")]
        // 可序列化标识
        // Serializable identifier
        [Serializable]
        class SaveData : ArchiveData
        {
            public string Test;
        }
    }
}
