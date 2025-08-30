using System;
using System.Collections.Generic;
using System.Linq;

namespace nijikabot.space_cat_games_devtool.Services
{
    public class ToolService
    {
        private readonly List<ToolModel> tools = new List<ToolModel>();

        public void AddTool(ToolModel tool)
        {
            tools.Add(tool);
        }

        public List<ToolModel> GetAllTools()
        {
            return tools.ToList();
        }

        public void RemoveTool(string toolId)
        {
            var tool = tools.FirstOrDefault(t => t.Id == toolId);
            if (tool != null)
            {
                tools.Remove(tool);
            }
        }
    }
}