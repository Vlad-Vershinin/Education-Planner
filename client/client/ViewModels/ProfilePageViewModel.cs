using client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        public User CurrentUser {  get; set; }
        public List<Course> EnrolledCourses { get; set; } 

        public ProfilePageViewModel()
        {
            CurrentUser = new User();
            EnrolledCourses = CurrentUser.EnrolledCourses;
        }

        public void SetUser(User user)
        {
            CurrentUser = user;
            EnrolledCourses = CurrentUser.EnrolledCourses;
        }



    }
}
