using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;

        public ObservableCollection<Idea> Ideas { get; } = new();

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [RelayCommand]
        private async Task ChargerAsync()
        {
            var ideas = await _ideaService.GetAllAsync();
            Ideas.Clear();
            foreach (var idea in ideas)
                Ideas.Add(idea);
        }
    }
}
