import java.util.Scanner;

class TicTacToe {
	public static void main(String[] args) {
		Tablero t = new Tablero();
		Jugador a;
		Jugador b;
		Jugador turno;
			
		Scanner sc = new Scanner(System.in);
		System.out.print("Ingrese su nombre: ");
		String nombre = sc.next();
	    
		//a = new JugadorPersona(nombre,'X');
		//b = new JugadorPC("Robot",'O');
		// Usar el inyector de dependencias para crear los jugadores
        Jugador jugadorRealA = DependencyInjector.injectPlayer("JugadorPersona", "humano", 'X');
        Jugador jugadorRealB = DependencyInjector.injectPlayer("JugadorPC", "Robot", 'O');
        
        // Usar proxy dinámico para interceptar llamadas
        a = JugadorProxy.createProxy(jugadorRealA);
        b = JugadorProxy.createProxy(jugadorRealB);

		turno = a;
		
		boolean seguir = t.hayJugadas();
		while (seguir) {
			limpiarConsola();
			System.out.println("Jugador 1 " + a.nombre() + " ficha: " + a.ficha());
			System.out.println("Jugador 2 " + b.nombre() + " ficha: " + b.ficha());
			System.out.println("======================");
			t.dibujarTablero();

			System.out.println("Turno del Jugador " + turno.nombre());
			int jugada = turno.jugar();

			if (t.marcarJugada(jugada, turno)) {
				if (t.esGanador(turno)) {
					limpiarConsola();
					t.dibujarTablero();
					System.out.println("\n\nHay un ganador, felicidades " + turno.nombre() + "!");
					seguir = false;
				} else {
					if (turno.nombre().equals(a.nombre())) {
						turno = b;
					} else {
						turno = a;
					}
					seguir = t.hayJugadas();
				}
			}

			if(seguir==false){
				System.out.println("Desea Jugar nuevamente? s\\n");
				String r = sc.next();
				if (r.contains("s")){
					seguir=true;
					t=new Tablero();
					Jugador tmp = a;
					a = b;
					b = tmp;
					turno = a;
				}
			}
		}
		sc.close();
	}

	public static void limpiarConsola() {
		System.out.print("\033[H\033[2J");
		System.out.flush();
	}
}