namespace Backend.Models.VM
{
    public class CreateEventVM
    {
        public EventVM EventVM { get; set; }
        public List<PoapVM> PoapVMs { get; set;}
        public List<ImageVM> ImageVMs { get; set;}
        public List<int> EventTypesIds { get; set;}

        public CreateEventVM(EventVM eventVM, List<PoapVM> poapVMs, List<ImageVM> imageVMs, List<int> eventTypesIds)
        {
            this.EventVM = eventVM;
            this.PoapVMs = poapVMs;
            this.ImageVMs = imageVMs;
            this.EventTypesIds = eventTypesIds;
        }
    }
}
