using TramPlannerLib.Models;
using TramPlannerLib.Responses;

namespace TramPlannerLib.Services
{
    public class TramContainer
    {
        private List<TramModel> Trams { get; set; } = [];
        private int TramIndexWaitingForMission = 0;
        private bool IsPlanningInProgress = false;

        public TramContainer()
        {
            this.InitTramPipeline();
        }

        // For demo purposes
        // ( Tram list would be somehow persisted/loaded from database upon backend start
        public void InitTramPipeline()
        {
            // Expecting that first moving tram will be the one with id 0
            Trams.Add(new TramModel { Id = 0, IsMissionPlanned = true });
            Trams.Add(new TramModel { Id = 1, IsMissionPlanned = true });
            Trams.Add(new TramModel { Id = 2, IsMissionPlanned = true });
            Trams.Add(new TramModel { Id = 3, IsMissionPlanned = false });
            TramIndexWaitingForMission = 3;
            Trams.Add(new TramModel { Id = 4, IsMissionPlanned = false });
            Trams.Add(new TramModel { Id = 5, IsMissionPlanned = false });
            Trams.Add(new TramModel { Id = 6, IsMissionPlanned = false });
            Trams.Add(new TramModel { Id = 7, IsMissionPlanned = false });
        }

        public List<TramModel> GetTrams()
        {
            return Trams;
        }

        // Plan mission for first found tram based on "pointer" TramIndexWaitingForMission
        // (Based on requirements - I do not currently see need for dealing with O(log N) complexity using for example binary search in some sorted list...)
        public async Task<PlanResponse> PlanMissionForTram()
        {
            if (IsPlanningInProgress)
            {
                return new PlanResponse
                {
                    IsPlanned = false,
                    TramId = -1,
                    Message = "Another client is planning mission. Please wait.."
                };
            }
            else
            {
                IsPlanningInProgress = true;

                await Task.Delay(5000); // Artificial delay to simulate that planning takes some time...

                if (TramIndexWaitingForMission < Trams.Count)
                {
                    Trams[TramIndexWaitingForMission].IsMissionPlanned = true;
                    TramIndexWaitingForMission++;
                    IsPlanningInProgress = false;
                    return new PlanResponse { IsPlanned = true, TramId = TramIndexWaitingForMission - 1, Message = "Mission planned" };
                }
                else
                {
                    IsPlanningInProgress = false;
                    return new PlanResponse
                    {
                        IsPlanned = false,
                        TramId = -1,
                        Message = "No more trams in the pipeline to be planned"
                    };
                }
            }
        }
    }
}
