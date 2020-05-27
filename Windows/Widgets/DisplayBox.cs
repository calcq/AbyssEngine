namespace AbyssBehavior{
    class DisplayBox:Widget{
        Camera camera;

        public DisplayBox(Vector position, Vector scale):base(position, scale){
            
        }

        protected override void Behaviour(){
            if(camera != null){
                for(int x = 0; x < transform.scale.x; x++){
                    for(int y = 0; y < transform.scale.y; y++){
                        for(int l = 0; l < layers; l++){
                            if(x < camera.canvas.scale.x && y < camera.canvas.scale.y)
                                canvas[x,y,l].SetupPoint(camera.canvas.GetPoint(x,y,l));
                        }
                    }
                }
            }
        }

        public override void SetData(object data){
            camera = (Camera)data;
            transform.SetupScale(camera.scale);
        }
    }
}