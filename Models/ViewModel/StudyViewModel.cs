using MVCWebApplication.Models.Studies;

namespace MVCWebApplication.Models.ViewModel
{
    public class StudyViewModel
    {
        public IEnumerable<Study> Studies { get; set; }
        
        public enum StudyStatus
        {
            Curiosity = 1,
            Work,
            University,
            IMD,
            Friends
        }

        public StudyViewModel(IEnumerable<Study> studies)
        {
            Studies = studies;
        }
    }
}
