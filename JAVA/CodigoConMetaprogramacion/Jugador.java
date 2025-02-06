public interface Jugador {
    // String nombre; 
    //char ficha;
     
    // public Jugador(String n, char f) 
    // {
    //    this.nombre = n;
    //     this.ficha = f;
    // }
    abstract String nombre();
    abstract char ficha(); 
    abstract int jugar();
}