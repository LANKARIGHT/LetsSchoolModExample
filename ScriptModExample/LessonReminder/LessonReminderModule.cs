using ProjectSchoolModNs.Publish;

namespace LessonReminder
{
    class LessonReminderModule : M_GameModuleBase
    {
        M_IGameContext gameContext;
        M_ITimeContext timeContext;
        M_IUIContext uiContext;
        ModFunction modFunction;
        protected override void OnCreate()
        {
            modContext.RunnerContext.TryGetContext(out gameContext);
            modContext.TryGetModFunction(out modFunction);
            timeContext = gameContext.TimeContext;
            uiContext = gameContext.UIContext;
        }
        protected override void OnStart()
        {
            timeContext.OnMinuteUpdate += OnMinuteUpdate;
        }

        protected override void OnStop()
        {
            timeContext.OnMinuteUpdate -= OnMinuteUpdate;
        }

        protected override void OnUnload()
        {
        }

        void OnMinuteUpdate()
        {
            int hour = timeContext.Hour;
            int minute = timeContext.Minute;
            if (modFunction.r1.Value && hour == 8 && minute == 0)
                uiContext.ShowTips("上班会了");
            else if (modFunction.r2.Value && hour == 8 && minute == 30)
                uiContext.ShowTips("第一节课上课啦");
            else if (modFunction.r2.Value && hour == 9 && minute == 30)
                uiContext.ShowTips("第一节课下课啦");
            else if (modFunction.r3.Value && hour == 10 && minute == 18)
                uiContext.ShowTips("第二节课上课啦");
            else if (modFunction.r3.Value && hour == 11 && minute == 18)
                uiContext.ShowTips("第二节课下课啦");
            else if (modFunction.r4.Value && hour == 12 && minute == 50)
                uiContext.ShowTips("第三节课上课啦");
            else if (modFunction.r4.Value && hour == 13 && minute == 50)
                uiContext.ShowTips("第三节课下课啦");
            else if (modFunction.r5.Value && hour == 14 && minute == 40)
                uiContext.ShowTips("第四节课上课啦");
            else if (modFunction.r5.Value && hour == 15 && minute == 40)
                uiContext.ShowTips("第四节课下课啦");
            else if (modFunction.r6.Value && hour == 17 && minute == 30)
                uiContext.ShowTips("放学了");
        }

        protected override void OnDispose()
        {
        }

        protected override void OnLoad()
        {
        }

    }
}
