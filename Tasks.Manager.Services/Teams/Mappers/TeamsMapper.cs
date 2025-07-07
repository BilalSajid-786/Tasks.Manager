using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.ServiceContracts.ViewModels.Teams;

namespace Tasks.Manager.Services.Teams.Mappers
{
    public static class TeamsMapper
    {
        //Entity to ViewModel
        public static TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel()
            {
                TeamId = team.TeamId,
                Name = team.Name,
                CreatedBy = team.CreatedByUser?.UserName
            };
        }


        //ViewModel to Entity
        public static Team ToTeam(object team)
        {
            if(team is TeamViewModel teamViewModel)
            {
                return new Team()
                {
                    TeamId = teamViewModel.TeamId,
                    Name = teamViewModel.Name,
                    //CreatedBy = Guid.Parse(teamViewModel.CreatedBy)
                };
            }
            if(team is AddTeamViewModel addTeamViewModel)
            {
                return new Team()
                {
                    Name = addTeamViewModel.Name
                };
            }
            if(team is UpdateTeamViewModel updateTeamViewModel)
            {
                return new Team()
                {
                    TeamId = updateTeamViewModel.TeamId,
                    Name = updateTeamViewModel.Name
                };
            }
            return new Team();
        }


        
    }
}
