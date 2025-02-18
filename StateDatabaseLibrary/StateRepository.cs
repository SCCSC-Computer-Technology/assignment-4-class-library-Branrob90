using BRoberts_CPT_206_Lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StateDatabaseLibrary
{
    public class StateRepository
    {
        private StatesDataDataContext dataContext;

        public StateRepository()
        {
            dataContext = new StatesDataDataContext();
        }

        // Get All States
        public List<StatesInfo> GetAllStates()
        {
            return dataContext.StatesInfos.ToList();
        }

        // Get a single state's details
        public StatesInfo GetStateByName(string stateName)
        {
            return dataContext.StatesInfos.FirstOrDefault(s => s.State == stateName);
        }

        // Add a new state
        public void AddState(StatesInfo newState)
        {
            try
            {
                dataContext.StatesInfos.InsertOnSubmit(newState);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding state: " + ex.Message);
            }
        }

        // Update an existing state
        public void UpdateState(StatesInfo updatedState)
        {
            try
            {
                var state = dataContext.StatesInfos.FirstOrDefault(s => s.State == updatedState.State);
                if (state != null)
                {
                    state.Population = updatedState.Population;
                    state.State_Flag_Description = updatedState.State_Flag_Description;
                    state.State_Flower = updatedState.State_Flower;
                    state.State_Bird = updatedState.State_Bird;
                    state.Colors = updatedState.Colors;
                    state.Largest_City = updatedState.Largest_City;
                    state.Second_Largest_City = updatedState.Second_Largest_City;
                    state.Third_Largest_City = updatedState.Third_Largest_City;
                    state.State_Capitol = updatedState.State_Capitol;
                    state.Median_Income = updatedState.Median_Income;
                    state.Percent_of_Computer_Jobs = updatedState.Percent_of_Computer_Jobs;
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating state: " + ex.Message);
            }
        }

        // Delete a state
        public void DeleteState(int id)
        {
            try
            {
                var state = dataContext.StatesInfos.FirstOrDefault(s => s.ID == id);
                if (state != null)
                {
                    dataContext.StatesInfos.DeleteOnSubmit(state);
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting state: " + ex.Message);
            }
        }

        // Search for states by keyword
        public List<StatesInfo> SearchStates(string keyword)
        {
            return dataContext.StatesInfos
                .Where(s => s.State.Contains(keyword) || s.Largest_City.Contains(keyword))
                .ToList();
        }

        // Sort states by population (Descending)
        public List<StatesInfo> SortByPopulation()
        {
            return dataContext.StatesInfos.OrderByDescending(s => s.Population).ToList();
        }
    }
}
}
