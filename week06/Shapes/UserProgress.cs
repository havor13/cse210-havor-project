using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable]
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
        SaveProgress("progress.xml"); // Auto-save after adding a goal
    }

    public void RecordGoalEvent(string goalName)
    {
        var goal = Goals.Find(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));

        if (goal != null)
        {
            goal.RecordProgress();
            TotalScore += goal.Points;
            Console.WriteLine($"🏆 Recorded progress for '{goal.Name}', Total Score: {TotalScore}");
            SaveProgress("progress.xml"); // Auto-save after recording a goal
        }
        else
        {
            Console.WriteLine("⚠️ Goal not found.");
        }
    }

    public void DisplayProgress()
    {
        Console.WriteLine("\n📊 Your Goals:");
        if (Goals.Count == 0)
        {
            Console.WriteLine("⚠️ No goals available.");
        }
        else
        {
            foreach (var goal in Goals)
            {
                Console.WriteLine(goal.DisplayStatus());
            }
        }
        Console.WriteLine($"💯 Total Score: {TotalScore}");
    }

    public void SaveProgress(string filename)
    {
        try
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserProgress),
                    new Type[] { typeof(SimpleGoal), typeof(EternalGoal), typeof(ChecklistGoal) });
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
                    XmlSerializer serializer = new XmlSerializer(typeof(UserProgress),
                        new Type[] { typeof(SimpleGoal), typeof(EternalGoal), typeof(ChecklistGoal) });
                    UserProgress loadedData = (UserProgress)serializer.Deserialize(fs);

                    Goals = loadedData.Goals ?? new List<Goal>();
                    TotalScore = loadedData.TotalScore;

                    Console.WriteLine("🔄 Progress loaded successfully!");
                    DisplayProgress(); // Ensure goals are displayed immediately after loading
                }
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
 