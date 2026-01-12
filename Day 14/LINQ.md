# Day 14 – .NET (C#)

### Problem Statement

### Code
```csharp
using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;

namespace AutonomousRobot.AI
{
    class SensorReading{
    public int SensorId{get;set;}
    public string Type{get; set;}
    public double Value{get; set;}
    public DateTime Timestamp{get;set;}
    public double Confidence;
    }
    enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    };
    class DecisionEngine
    {
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory,DateTime fromTime)
        {
            return sensorHistory.Where(r=>r.Timestamp>=fromTime).ToList();
        }
        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Any(r=>r.Type=="Battery"&& r.Value<20);
        }
        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            var res=readings.Where(r=> r.Type=="Distance").Select(r=>r.Value);
            if (res.Any())
            {
                return res.Min();
            }
            else
            {
                return double.MaxValue;
            }
        }
        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings.Where(r=>r.Type=="Temperature" ).All(r=> r.Value<90);
        }
        public double GetAverageVibration(List<SensorReading> readings)
        {
            var res=readings.Where(r=>r.Type=="Vibration").Select(r=>r.Value);
            if (res.Any())
            {
                return res.Average();
            }
            return 0;
        }
        public Dictionary<string,double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            return sensorHistory.GroupBy(r=>r.Type).ToDictionary(g=>g.Key,g=>g.Average(r=>r.Confidence));
        }
        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory.GroupBy(r=>r.Type).Where(g=>g.Count(r=>r.Confidence<0.4)>2).Select(g=>g.Key).ToList();

        }
        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var res=sensorHistory.Where(r=>r.Type=="Battery").OrderBy(r=>r.Timestamp).Select(r=>r.Value).ToList();
            return res.Zip(res.Skip(1),(a,b)=>b<a).All(x=>x);
        }
        public double GetWeightedDistance( List<SensorReading> readings)
        {
            var res=readings.Where(r=>r.Type=="Distance");
            double WeightedSum=res.Sum(r=>r.Value*r.Confidence);
            double TotalConfidence=res.Sum(r=>r.Confidence);
            if (TotalConfidence == 0)
            {
                return double.MaxValue;
            }
            return WeightedSum/TotalConfidence;
        }
        public RobotAction DecideRobotAction(List<SensorReading> recentReadings,List<SensorReading> sensorHistory)
        {
            if(IsBatteryCritical(recentReadings)) return RobotAction.Stop;

            if(IsBatteryDrainingFast(sensorHistory)) return RobotAction.Stop;
            
            if(GetNearestObstacleDistance(recentReadings)<1.0) return RobotAction.Reroute;

            if(!IsTemperatureSafe(recentReadings)) return RobotAction.SlowDown;

            return RobotAction.Continue;

        }

    }
    class Program
    {
        static void Main()
        {
            DateTime now = DateTime.Now;


            List<SensorReading> sensorHistory=new List<SensorReading>
            {
            new SensorReading { SensorId=1, Type="Distance", Value=0.8, Confidence=0.9, Timestamp=now.AddSeconds(-8) },
            new SensorReading { SensorId=2, Type="Battery", Value=18, Confidence=0.8, Timestamp=now.AddSeconds(-7) },
            new SensorReading { SensorId=3, Type="Temperature", Value=92, Confidence=0.7, Timestamp=now.AddSeconds(-6) },
            new SensorReading { SensorId=4, Type="Vibration", Value=8.2, Confidence=0.6, Timestamp=now.AddSeconds(-5) },
            new SensorReading { SensorId=5, Type="Battery", Value=75, Confidence=0.9, Timestamp=now.AddSeconds(-4) },
            new SensorReading { SensorId=6, Type="Distance", Value=2.5, Confidence=0.5, Timestamp=now.AddSeconds(-3) }
        
            };
          
            DecisionEngine engine = new DecisionEngine();

    // TASK 1: GetRecentReadings
    var recentReadings = engine.GetRecentReadings(sensorHistory, now.AddSeconds(-10));

    // TASK 2: IsBatteryCritical
    bool isBatteryCritical =engine.IsBatteryCritical(recentReadings);
    Console.WriteLine($"Task 2 - Battery Critical: {isBatteryCritical}");

    // TASK 3: GetNearestObstacleDistance
    double nearestObstacle = engine.GetNearestObstacleDistance(recentReadings);
    Console.WriteLine($"Task 3 - Nearest Obstacle Distance: {nearestObstacle}");

    // TASK 4: IsTemperatureSafe
    bool isTemperatureSafe = engine.IsTemperatureSafe(recentReadings);
    Console.WriteLine($"Task 4 - Temperature Safe: {isTemperatureSafe}");

    // TASK 5: GetAverageVibration
    double averageVibration = engine.GetAverageVibration(recentReadings);
    Console.WriteLine($"Task 5 - Average Vibration: {averageVibration}");

    // TASK 6: CalculateSensorHealth
    var sensorHealth = engine.CalculateSensorHealth(sensorHistory);
    Console.WriteLine("Task 6 - Sensor Health:");
    foreach (var h in sensorHealth) Console.WriteLine($"{h.Key} -> {h.Value}");

    // TASK 7: DetectFaultySensors
    var faultySensors = engine.DetectFaultySensors(sensorHistory);
    Console.Write("Task 7 - Faulty Sensors:");
    Console.WriteLine(faultySensors.Count == 0 ? "None" : string.Join(", ", faultySensors));

    // TASK 8: IsBatteryDrainingFast
    bool isBatteryDrainingFast = engine.IsBatteryDrainingFast(sensorHistory);
    Console.WriteLine($"Task 8 - Battery Draining Fast: {isBatteryDrainingFast}");

    // TASK 9: GetWeightedDistance
    double weightedDistance = engine.GetWeightedDistance(recentReadings);
    Console.WriteLine($"Task 9 - Weighted Distance: {weightedDistance}");

    // TASK 10: DecideRobotAction
    RobotAction action = engine.DecideRobotAction(recentReadings, sensorHistory);
    Console.WriteLine($"Robot Action: {action}");
    
        }
    }

}
```
