using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class Survey
    {
        //public int ID { get; set; }

        [Required(ErrorMessage = "* Choose A Park")]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "* Field Cannot Be Blank")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Choose A State")]
        public string State { get; set; }

        [Required(ErrorMessage = "* Choose An Option")]
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> StatesOfResidence = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "--Select A State", Value=null,Selected=true,Disabled=true},
            new SelectListItem() {Value = "Alabama", Text = "Alabama"},
            new SelectListItem() {Value = "Alaska", Text = "Alaska"},
            new SelectListItem() {Value = "Arizona", Text = "Arizona"},
            new SelectListItem() {Value = "Arkansas", Text = "Arkansas"},
            new SelectListItem() {Value = "California", Text = "California"},
            new SelectListItem() {Value = "Colorado", Text = "Colorado"},
            new SelectListItem() {Value = "Connecticut", Text = "Connecticut"},
            new SelectListItem() {Value = "Delaware", Text = "Delaware"},
            new SelectListItem() {Value = "Florida", Text = "Florida"},
            new SelectListItem() {Value = "Georgia", Text = "Georgia"},
            new SelectListItem() {Value = "Hawaii", Text = "Hawaii"},
            new SelectListItem() {Value = "Idaho", Text = "Idaho"},
            new SelectListItem() {Value = "Illinois", Text = "Illinois"},
            new SelectListItem() {Value = "Indiana", Text = "Indiana"},
            new SelectListItem() {Value = "Iowa", Text = "Iowa"},
            new SelectListItem() {Value = "Kansas", Text = "Kansas"},
            new SelectListItem() {Value = "Kentucky", Text = "Kentucky"},
            new SelectListItem() {Value = "Louisiana", Text = "Louisiana"},
            new SelectListItem() {Value = "Main", Text = "Main"},
            new SelectListItem() {Value = "Maryland", Text = "Maryland"},
            new SelectListItem() {Value = "Massachusetts", Text = "Massachusetts"},
            new SelectListItem() {Value = "Michigan", Text = "Michigan"},
            new SelectListItem() {Value = "Minnesota", Text = "Minnesota"},
            new SelectListItem() {Value = "Missippi", Text = "Missippi"},
            new SelectListItem() {Value = "Missouri", Text = "Missouri"},
            new SelectListItem() {Value = "Montana", Text = "Montana"},
            new SelectListItem() {Value = "Nebraska", Text = "Nebraska"},
            new SelectListItem() {Value = "Nevada", Text = "Nevada"},
            new SelectListItem() {Value = "New Hampshire", Text = "New Hampshire"},
            new SelectListItem() {Value = "New Jersey", Text = "New Jersey"},
            new SelectListItem() {Value = "New Mexico", Text = "New Mexico"},
            new SelectListItem() {Value = "New York", Text = "New York"},
            new SelectListItem() {Value = "North Carolina", Text = "North Carolina"},
            new SelectListItem() {Value = "North Dakota", Text = "North Dakota"},
            new SelectListItem() {Value = "Ohio", Text = "Ohio"},
            new SelectListItem() {Value = "Oklahoma", Text = "Oklahoma"},
            new SelectListItem() {Value = "Oregon", Text = "Oregon"},
            new SelectListItem() {Value = "Pennsylvania", Text = "Pennsylvania"},
            new SelectListItem() {Value = "Rhode Island", Text = "Rhode Island"},
            new SelectListItem() {Value = "South Carolina", Text = "South Carolina"},
            new SelectListItem() {Value = "South Dakota", Text = "South Dakota"},
            new SelectListItem() {Value = "Tennessee", Text = "Tennessee"},
            new SelectListItem() {Value = "Texas", Text = "Texas"},
            new SelectListItem() {Value = "Utah", Text = "Utah"},
            new SelectListItem() {Value = "Vermont", Text = "Vermont"},
            new SelectListItem() {Value = "Virginia", Text = "Virginia"},
            new SelectListItem() {Value = "Washington", Text = "Washington"},
            new SelectListItem() {Value = "West Virginia", Text = "West Virginia"},
            new SelectListItem() {Value = "Wisconsin", Text = "Wisconsin"},
            new SelectListItem() {Value = "Wyoming", Text = "Wyoming"}
        };

        public static List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem(){ Text = "--Select A Level", Selected=true, Value = null, Disabled=true},
            new SelectListItem(){ Text="Inactive", Value="Inactive"},
            new SelectListItem(){ Text="Sedentary", Value="Sedentary"},
            new SelectListItem(){ Text="Active",Value="Active"},
            new SelectListItem(){ Text="Extremely Active", Value="Extremely Active"}
        };
    }
}
