using MVCWebApplication.Models.Studies;

namespace MVCWebApplication.Models.ViewModel
{
    public class StudyViewModel
    {
        public IEnumerable<Study> Studies { get; set; }

        public StudyViewModel(IEnumerable<Study> studies)
        {
            Studies = studies;
        }
    }
}
