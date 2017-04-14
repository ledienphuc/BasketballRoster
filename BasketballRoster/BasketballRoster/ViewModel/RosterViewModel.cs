using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace BasketballRoster.ViewModel
{
    using Model;
    class RosterViewModel
    {
        public ObservableCollection<PlayerViewModel> Starters { get; set; }
        public ObservableCollection<PlayerViewModel> Bench { get; set; }

        private Roster _roster;
        public string TeamName { get; set; }

        public RosterViewModel(Roster roster)
        {
            _roster = roster;
            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();

            TeamName = roster.TeamName;

            UpdateRoster();
        }

        private void UpdateRoster()
        {
            var startingPlayers =
                from player in _roster.Players
                where player.Starter
                select player;
            Starters.Clear();
            foreach (Player player in startingPlayers)
            {
                Starters.Add(new PlayerViewModel(player.Name, player.Number));
            }

            var benchPlayers =
                from player in _roster.Players
                where !player.Starter
                select player;
            Bench.Clear();
            foreach (Player player in benchPlayers)
            {
                Bench.Add(new PlayerViewModel(player.Name, player.Number));
            }
        }
    }
}
