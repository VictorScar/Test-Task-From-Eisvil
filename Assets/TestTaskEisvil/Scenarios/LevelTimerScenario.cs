using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TestTaskEisvil._Level;
using TestTaskEisvil.UI;

namespace TestTaskEisvil.Scenarios
{
    public class LevelTimerScenario : GameScenario<LevelTimerScenarioData>
    {
        private LevelTimer _timer;
        private TimerViewPanel _timerView;


        protected override void OnInit(LevelTimerScenarioData data)
        {
            _timer = data.Timer;
            _timerView = data.TimerViewPanel;
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            _timer.onTimeChanged += ShowCurrentTime;
            
            _data.Timer.ResetTimer();
            _data.Timer.StartTimer();

            await UniTask.WhenAny(UniTask.WaitUntilCanceled(token), UniTask.WaitUntil(() => _isStopped, cancellationToken: token));
        }

        protected override void OnScenarioEnd()
        {
            _timer.onTimeChanged -= ShowCurrentTime;
            _timer.Stop();
        }

        private void ShowCurrentTime(TimeSpan time)
        {
            _timerView.Data = time;
        }
    }

    public struct LevelTimerScenarioData: IScenarioData
    {
        public LevelTimer Timer;
        public TimerViewPanel TimerViewPanel;
    }
}