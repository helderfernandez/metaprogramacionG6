import java.util.Scanner;
public class JugadorPersona extends Jugador {
	public JugadorPersona(String n, char f) {
		super(n, f);
	}

	@Override
	public int jugar() {
		System.out.println("=>Ingrese posicion del 0 al 8 desde teclado (" + this.ficha + "):");
		Scanner s = new Scanner(System.in);
		int r = s.nextInt();
		s.close();
		return r;
	}
}
