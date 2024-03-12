using InstitePro.Models;

namespace InstitePro.ViewModels
{
    public class EmployeeNameWithBrchListMsgTempColorViewModel
    {
        //-------------Employee-----
        public int ID { get; set; }
        public string NAme { get; set; }
        //------------Extra info
        public string MEssage { get; set; }
        public List<string> Branches { get; set; }
        public int  Temp { get; set; }
        public string Color { get; set; }
    }
}
