using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace TaskForge.UI.Models
{
    public partial class TaskModel : ObservableObject
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string CreatedAt { get; set; }

        [ObservableProperty]
        private bool isEditMode;
    }
}



