namespace Model;

public class ChatbotResponse
{
    public string Out { get; set; }
    public string RequestDuration { get; set; }
    
    public StepsBenchmark StepsBenchmark { get; set; }
    
    public string Who { get; set; }
    public int WhoType { get; set; }
}