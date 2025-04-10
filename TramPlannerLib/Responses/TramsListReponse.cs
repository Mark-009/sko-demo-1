using TramPlannerLib.Models;

namespace TramPlannerLib.Responses
{
    public class TramsListResponse
    {
        public List<TramModel> Trams { get; set; } = [];
    }
}
