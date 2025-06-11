using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable] // Ensures the class can be serialized
public class UserProgress
{
    [XmlElement("Goals")] 
    public List<Goal> Goals { get; set; } = new List<Goal>();

    [XmlElement("TotalScore")] 
    public int TotalScore { get; set; }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
        Console.WriteLine($"✅ Added new goal: {goal.Name}");
    }

    public void RecordGoalEvent(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase))
            {
                goal.RecordProgress();
                TotalScore += goal.Points;
                Console.WriteLine($"🏆 Recorded progress for '{goal.Name}', Total Score: {TotalScore}");
                return;
            }
        }
        Console.WriteLine("⚠️ Goal not found.");
    }

    public void DisplayProgress()
    {
        Console.WriteLine("\n📊 Your Goals:");
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
        Console.WriteLine($"💯 Total Score: {TotalScore}");
    }

    public void SaveProgress(string filename)
    {
        try
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserProgress));
                serializer.Serialize(fs, this);
            }
            Console.WriteLine("📁 Progress saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error saving progress: {ex.Message}");
        }
    }

    public void LoadProgress(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserProgress));
                    UserProgress loadedData = (UserProgress)serializer.Deserialize(fs);
                    
                    Goals = new List<Goal>(); // Ensure a fresh list before loading

                    foreach (var goal in loadedData.Goals)
                    {
                        // Ensure goal types are preserved after loading
                        if (goal is SimpleGoal)
                            Goals.Add(new SimpleGoal(goal.Name, "A simple goal", goal.Points));
                        else if (goal is EternalGoal)
                            Goals.Add(new EternalGoal(goal.Name, "An eternal goal", goal.Points));
                        else if (goal is ChecklistGoal checklistGoal)
                            Goals.Add(new ChecklistGoal(checklistGoal.Name, "Checklist goal", checklistGoal.Points, checklistGoal.TargetCount, checklistGoal.BonusPoints));
                    }
                    
                    TotalScore = loadedData.TotalScore;
                }
                Console.WriteLine("🔄 Progress loaded successfully!");
            }
            else
            {
                Console.WriteLine("⚠️ No save file found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error loading progress: {ex.Message}");
        }
    }
}
