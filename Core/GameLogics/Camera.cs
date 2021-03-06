namespace AbyssBehavior{
    public class Camera{
        Location location;
        Object spectrate;
        Vector _scale;
        Canvas _canvas;

        public Canvas canvas{get{return _canvas;}}

        public Vector scale{get{return _scale;}}

        public Camera(){
            _canvas = CanvasFactory.CreateCanvas(2, 2);
            _scale = new Vector(2,2);
        }

        // public Camera(int x, int y){
        //     _canvas = new Canvas(x,y);
        //     _scale = new Vector(x,y);
        // }

        public Camera(Vector scale){
            _canvas = CanvasFactory.CreateCanvas(scale.x, scale.y);
            _scale = new Vector(scale);
        }

        public void SetSpectrate(Object obj){
            spectrate = obj;
        }

        public void SetLocation(Location location){
            this.location = location;
        }

        public void Update(){
            if(spectrate != null && location != null){
                for(int x = 0; x < scale.x; x++){
                    for(int y = 0; y < scale.y; y++){
                        Vector temp = new Vector(spectrate.position.x - canvas.scale.x / 2 + x, spectrate.position.y - canvas.scale.y / 2 + y);
                        for(int l = 0; l < location.layers; l++){
                            if(temp.x > -1 && temp.x < location.scale.x && temp.y > -1 && temp.y < location.scale.y)
                                if(location.GetObject(temp.x,temp.y,l) != null)
                                    canvas.Set(x,y,l,location.GetObject(temp.x,temp.y,l).texture);
                                else
                                    continue;
                            else
                                canvas.Set(x,y,l,"dark");
                        }
                    }
                }
            }/* else
                Core.ThrowError(7); */
        }
    }
}