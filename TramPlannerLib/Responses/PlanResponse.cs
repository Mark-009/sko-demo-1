namespace TramPlannerLib.Responses
{
    public class PlanResponse
    {
        public int TramId { get; set; }
        public string Message { get; set; } = "";
        public bool IsPlanned { get; set; }
    }
}
