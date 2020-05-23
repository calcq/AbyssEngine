using System.Collections.Generic;

namespace AbyssBehavior{
    class Logic{
        protected delegate void action();
        protected Window parent;

        
        protected action menuUp;
        protected action menuDown;
        protected action select;

        protected Dictionary<Control.Actions, action> control;

        protected Dictionary<string, action> menu;

        public Logic(Window parent){
            this.parent = parent;
            menuUp = MenuUp;
            menuDown = MenuDown;
            select = Select;
            control = new Dictionary<Control.Actions, action>();
            menu = new Dictionary<string, action>();
            control.Add(Control.Actions.CursoreUp, menuUp);
            control.Add(Control.Actions.CursoreDown, menuDown);
            control.Add(Control.Actions.Accept, select);
            Initalization();
        }
        public void DefaultUpdate(){
            if(Core.currentWindow == parent){
                if(control.ContainsKey(Control.action)){
                control[Control.action]();
                }
                Update();
            }
        }

        protected virtual void Initalization(){

        }
        
        protected virtual void Update(){

        }

        protected void MenuUp(){
            int index;
            if(parent.menu.Contains(parent.selectedElement) && parent.menu.Count > 0){
                index = parent.menu.IndexOf(parent.selectedElement);
                if(index - 1 < 0){
                    parent.selectedElement = parent.menu[parent.menu.Count - 1];
                }else{
                    parent.selectedElement = parent.menu[index - 1];
                }
            }else{
                Core.ThrowError(2);
            }
        }
        protected void MenuDown(){
            int index;
            if(parent.menu.Contains(parent.selectedElement) && parent.menu.Count > 0){
                index = parent.menu.IndexOf(parent.selectedElement);
                if(index + 1 >= parent.menu.Count){
                    parent.selectedElement = parent.menu[0];
                }else{
                    parent.selectedElement = parent.menu[index + 1];
                }
            }else{
                Core.ThrowError(3);
            }
        }

        protected void Select(){
            if(menu.ContainsKey(parent.selectedElement)){
                menu[parent.selectedElement]();
            }else
                Core.ThrowError(6);
        }
    }
}