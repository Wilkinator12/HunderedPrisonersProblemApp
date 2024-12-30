using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;

namespace WpfUI.Data
{
    public class UIDataAccess : IUIDataAccess
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;


        private const string _riddleRulesFilePathName = "RiddleRulesFilePath";
        private const string _strategyExplanationsFilePathName = "StrategyExplanationsFilePath";


        public UIDataAccess(IConfiguration config, ILogger<UIDataAccess> logger)
        {
            _config = config;
            _logger = logger;
        }



        public ObservableCollection<string> GetRiddleRules()
        {
            string? fileName = _config.GetValue<string>(_riddleRulesFilePathName);
            if (fileName == null)
            {
                var error = $"Could not find {_riddleRulesFilePathName}";

                _logger.LogError(error);
                throw new Exception(error);
            }



            var listOfRiddleRules = File.ReadAllLines(fileName).ToList();

            return new ObservableCollection<string>(listOfRiddleRules);
        }

        public ObservableCollection<StrategyExplanation> GetStrategyExplanations()
        {
            string? fileName = _config.GetValue<string>(_strategyExplanationsFilePathName);
            if (fileName == null)
            {
                var error = $"Could not find {_strategyExplanationsFilePathName}";

                _logger.LogError(error);
                throw new Exception(error);
            }



            var output = new ObservableCollection<StrategyExplanation>();


            string[] fileRows = File.ReadAllLines(fileName);
            foreach (var row in fileRows)
            {
                string[] cols = row.Split("::");

                var newStrategyExplanation = new StrategyExplanation { StrategyName = cols[0], Explanation = cols[1] };

                output.Add(newStrategyExplanation);
            }


            return output;
        }
    }
}
