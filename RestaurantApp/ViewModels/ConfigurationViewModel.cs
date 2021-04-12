using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        public ConfigurationViewModel()
        {

        }

        public DbSettings DbSettings { get; set; }
    }
}
