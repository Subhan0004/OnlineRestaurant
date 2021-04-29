using RestaurantApp.Command.Categories;
using RestaurantApp.Enums;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.ViewModels.UserControls
{
    public class CategoriesViewModel : BaseControlViewModel
    {
        public CategoriesViewModel()
        {

        }

        public override string Header => "Categories";

        private CategoryModel currentCategory = new CategoryModel();
        public CategoryModel CurrentCategory
        {
            get => currentCategory;
            set
            {
                currentCategory = value;
                OnPropertyChanged(nameof(CurrentCategory));
               
            }
        }

        private CategoryModel selectedCategory = new CategoryModel();
        public CategoryModel SelectedCategory
        {
            get => selectedCategory;

            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));

                CurrentCategory = selectedCategory?.Clone();
                if (SelectedCategory != null)
                {
                    CurrentSituation = (int)Situation.SELECTED;
                }
            }
        }

        private List<CategoryModel> allCategories;
        public List<CategoryModel> AllCategories 
        {
            get => allCategories;
            set 
            {
                allCategories = value;
                OnPropertyChanged(nameof(AllCategories));
            }
        }

        private string searchText = string.Empty;
        public string SearchText 
        {
            get => searchText;
            set 
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateDataFiltered();
            }
        }

        public void UpdateDataFiltered() 
        {
            IEnumerable<CategoryModel> filteredCategories = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredCategories = AllCategories;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredCategories = AllCategories.Where(x =>
                        x.Name.ToLower().Contains(lowerSearchText) ||
                        x.Note.ToLower().Contains(lowerSearchText) ||
                        (x.Note != null && x.Note.ToLower().Contains(lowerSearchText)));
            }

            Categories.Clear();

            foreach (var item in filteredCategories)
            {
                Categories.Add(item);
            }
        }

        private ObservableCollection<CategoryModel> categories = new ObservableCollection<CategoryModel>();
        public ObservableCollection<CategoryModel> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public SaveCategoryCommand Save => new SaveCategoryCommand(this);
        public RejectCategoryCommand Reject => new RejectCategoryCommand(this);
        public DeleteCategoryCommand Delete => new DeleteCategoryCommand(this);
        public ExportExcelCategoryCommand ExportExcel => new ExportExcelCategoryCommand(this);

    }
}
