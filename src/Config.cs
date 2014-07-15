using System;

namespace ZBreak
{
    public class Config
    {
        private const String FilePath = @".\config.ini";
        private const String Section = @"ZBreak";

        #region 属性
        //采集像素点的数量
        public static Int32 CollectPixelCount {get; set; }
        //两次采集的像素有超过一定百分比不同，则认为屏幕属于活动状态
        public static Double DecidePercent { get; set; }
        //活动状态监测间隔，单位毫秒
        public static Int32 TimerInterval { get; set; }
        //最短休息时间，单位分钟
        public static Int32 MinBreakTime { get; set; }
        //第一次提示时间，单位分钟
        public static Int32 FirstAlarmTime { get; set; }
        //每一次累加时间，单位分钟
        public static Int32 MoreTime { get; set; }
        #endregion

        public static void Read()
        {
            try
            {
                IniFile config = new IniFile(FilePath);
                CollectPixelCount = Int32.Parse(config.Read(Section, "CollectPixelCount","1000"));
                DecidePercent = Double.Parse(config.Read(Section, "DecidePercent","0.05"));
                TimerInterval = Int32.Parse(config.Read(Section, "TimerInterval","60000"));
                MinBreakTime = Int32.Parse(config.Read(Section, "MinBreakTime","5"));
                FirstAlarmTime = Int32.Parse(config.Read(Section, "FirstAlarmTime","60"));
                MoreTime = Int32.Parse(config.Read(Section, "MoreTime","10"));
            }
            catch (Exception)
            {
                throw new ApplicationException("读取配置失败");
            }
        }

        public static void Save()
        {
            IniFile config = new IniFile(FilePath);
            config.Write(Section, "CollectPixelCount", CollectPixelCount.ToString());
            config.Write(Section, "DecidePercent", DecidePercent.ToString());
            config.Write(Section, "TimerInterval", TimerInterval.ToString());
            config.Write(Section, "MinBreakTime", MinBreakTime.ToString());
            config.Write(Section, "FirstAlarmTime", FirstAlarmTime.ToString());
            config.Write(Section, "MoreTime", MoreTime.ToString());
        }
    }
}
