using ModFrameworkNs.Publish;
using ProjectSchoolModNs.Publish;

[assembly: ModEntry]

namespace LessonReminder
{
    class ModFunction : BootableModFunctionBase
    {
        M_IGameContext gameContext;

        public ISettingProperty<bool> r1;
        public ISettingProperty<bool> r2;
        public ISettingProperty<bool> r3;
        public ISettingProperty<bool> r4;
        public ISettingProperty<bool> r5;
        public ISettingProperty<bool> r6;

        protected override void OnInit()
        {
            context.RunnerContext.TryGetContext(out gameContext);
            var block = context.Settings.RegisterSettingBlock("上课提醒");
            r1 = block.RegisterToggle("r1", true);
            r2 = block.RegisterToggle("r2", true);
            r3 = block.RegisterToggle("r3", true);
            r4 = block.RegisterToggle("r4", true);
            r5 = block.RegisterToggle("r5", true);
            r6 = block.RegisterToggle("r6", true);
        }

        protected override void OnEnable()
        {
            gameContext.ModuleContext.RegisterGameModule<LessonReminderModule>(context);
        }
        protected override void OnDisable()
        {
            gameContext.ModuleContext.UnregisterGameModule<LessonReminderModule>(context);
        }

        protected override void OnDispose()
        {
        }
    }
}
