using AbyssPlugins;

namespace AbyssBehavior{
    class PluginDescriptionLogic:Logic{

        string name;
        string description;
        public PluginDescriptionLogic(Window parent):base(parent){}
        public override void Initialization(){
            name = "";
            description = "";
            control.Add(KeysToAction.Actions.Deny, Exit);
            Connect("pluginInfo", SetData);
        }

        protected override void Update(){
            window.GetWidget<TextBox>("name").text = name;
            window.GetWidget<TextBox>("description").text = description;
        }

        protected void SetData(object pluginInfo){
            IPlugin plugin = (IPlugin)pluginInfo;
            name = plugin.name;
            description = plugin.description;
        }

        protected void Exit(){
            Core.CloseWindow(window);
        }
    }
}