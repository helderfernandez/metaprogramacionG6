import java.util.Random;
@InjectPlayer
public class JugadorPC implements Jugador {
	String nombre; 
    char ficha;
	static Random r;
	static{
		System.out.println("inicializando random...");
		r = new Random();
	}

	public JugadorPC(String n, char ficha) {
		this.nombre = "PC " + n;
		this.ficha = ficha;
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
		int t = 0;
		System.out.print("PC: pensando");
		while (t < 3) {
			System.out.print(".");
			try {
				Thread.sleep(1000);
			} catch (InterruptedException ex) {
				Thread.currentThread().interrupt();
			}
			t++;
			r.nextInt(8);
		}
		return r.nextInt(8);
	}
}