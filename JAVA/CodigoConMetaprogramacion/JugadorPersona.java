import java.util.Scanner;
@InjectPlayer
public class JugadorPersona implements Jugador {
	private static Scanner s;
	static{
		System.out.println("inicializando scanner...");
		s = new Scanner(System.in);
	}

	String nombre; 
    char ficha;
   
	public JugadorPersona(String n, char f) {
		this.nombre = n;
		this.ficha = f;
	}

	@Override
	public String nombre(){
		return this.nombre;		
	}
	
	@Override
    public char ficha(){
		return this.ficha;
	}

	@Override
	public int jugar() {
		System.out.println("=>Ingrese posicion del 0 al 8 desde teclado (" + this.ficha + "):");
		int r = s.nextInt();
		return r;
	}	
}
