namespace ConsoleApp9;

using System;
using System.Threading;

public delegate void OnclickCurrentTime(DateTime time);
public delegate void OnclickAlarmtime(DateTime time);

public class Alarm
{
    public DateTime AlarmTime { get; set; }
    public DateTime CurrTime { get; set; }
    public event OnclickCurrentTime OnclickCurrentTimeEvent;
    public event OnclickAlarmtime OnclickAlarmtimeEvent;

    public Alarm()
    {
        CurrTime = DateTime.Now;
    }

    public void StartAlarm()
    {
        Console.WriteLine("Alarm started");
        while (true)
        {
            CurrTime = DateTime.Now;
            OnclickCurrentTimeEvent(CurrTime);
            if (AlarmTime <= DateTime.Now)
            {
                OnclickAlarmtimeEvent(CurrTime);
                break;
            }
            Thread.Sleep(1000);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Alarm alarm = new Alarm();
        alarm.OnclickAlarmtimeEvent += delegate(DateTime time)
        {
            Console.WriteLine($"alarm alarm at { time }");
        };
        alarm.OnclickCurrentTimeEvent += delegate(DateTime time)
        {
            Console.WriteLine($"OnclickCurrentTimeEvent {time}");
        };
        alarm.AlarmTime = DateTime.Now.AddSeconds(10);
        alarm.StartAlarm();
    }
}