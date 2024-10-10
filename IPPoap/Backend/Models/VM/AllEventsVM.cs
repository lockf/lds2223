namespace Backend.Models.VM
{
    public class AllEventsVM
    {
        public EventVMv2 Event { get; set; }
        public List<ImageVM> Images { get; set; }

        public AllEventsVM(EventVMv2 Event, List<ImageVM> Images)
        {
            this.Event = Event;
            this.Images = Images;
        }
    }
}
