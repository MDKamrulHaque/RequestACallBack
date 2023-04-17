using CallBackForm.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;

namespace CallBackForm.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] HttpClient httpClient { get; set; }

         private UserDetails callBackForm = new UserDetails();
                
        public IList<ListOfSchools> schools => new List<ListOfSchools>()
        {
            new ListOfSchools{ Id = 1, SchoolName = "School of Sport and Health Science" },
            new ListOfSchools{ Id = 2,  SchoolName = "School of Management" },
            new ListOfSchools{ Id = 3, SchoolName = "School of Technology" },
            new ListOfSchools{ Id = 4,SchoolName = "School of Education and Social Policy" },
            new ListOfSchools{ Id = 5, SchoolName = "School of Art and Design" }
        };
        private async Task HandleCallBackRequest()
        {
            if (ValidateBestTimeToContact() == true)
            {
                var response = await httpClient.PostAsJsonAsync<UserDetails>("/api/CallBackRequest", callBackForm);

                if (response.IsSuccessStatusCode)
                {
                    NavigationManager.NavigateTo("/requestsuccessful");
                }
            }

        }

        private bool ValidateBestTimeToContact()
        {
            
            DateTime bestTimeToContact = callBackForm.BestTimeToContact;
            DateTime currentTime = DateTime.Now;

            if (bestTimeToContact < currentTime)
            {
                return false;
            }

            if ((bestTimeToContact.TimeOfDay < new TimeSpan(9, 0, 0) || bestTimeToContact.TimeOfDay > new TimeSpan(16, 30, 0))
                 || (bestTimeToContact.Date == DateTime.Today && bestTimeToContact.TimeOfDay > new TimeSpan(16, 30, 0)))
            {
                return false;
            }

            if (bestTimeToContact.Date < DateTime.Today)
            {
                return false;
            }

            return true;
        }        



        }
}
